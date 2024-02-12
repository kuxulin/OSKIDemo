using Microsoft.EntityFrameworkCore;
using OSKIDemo.Data;
using OSKIDemo.Interfaces;
using OSKIDemo.Models;
using OSKIDemo.Models.ViewModels;

namespace OSKIDemo.Repositories;

public class TestRepository : ITestRepository
{
    private readonly DataContext _dataContext;

    public TestRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<TestGeneralViewModel>> GetTestsOwnedByUserAsync(Guid userId)
    {
        var userTests = await _dataContext.Tests
            .SelectMany(t => t.UserTests
                .Where(ut => ut.UserId == userId.ToString())
                .Select(ut => new TestGeneralViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Mark = ut.Mark,
                    IsCompleted = ut.IsCompleted,
                })).ToListAsync();

        var s = (Test x) => x.Questions.Count < 10 ? 11 : 12;
        var usersdfsd = _dataContext.Tests.OrderBy(s);
        return userTests;
    }

    public async Task<UserTest> GetUserTestAsync(Guid testId, Guid userId)
    {
        var userTest = await _dataContext.UserTests
             .Where(ut => ut.TestId == testId && ut.UserId == userId.ToString())
             .FirstOrDefaultAsync();

        return userTest;
    }

    public async Task<TestSpecificViewModel> GetTestByIdAsync(Guid testId)
    {
        var test = await _dataContext.Tests
             .Include(t => t.Questions)
             .ThenInclude(q => q.Answers)
             .Where(t => t.Id == testId)
             .Select(t => new TestSpecificViewModel
             {
                 Id = t.Id,
                 Name = t.Name,
                 Questions = t.Questions
             }).FirstOrDefaultAsync();

        return test;
    }

    public async Task PassTestAsync(UserTest userTest, IEnumerable<Guid> answerIds)
    {
        var mark = await _dataContext.Answers
            .Where(a => answerIds.Contains(a.Id) && a.IsRight)
            .CountAsync();

        userTest.Mark = mark;
        userTest.IsCompleted = true;
        await _dataContext.SaveChangesAsync();
    }
}
