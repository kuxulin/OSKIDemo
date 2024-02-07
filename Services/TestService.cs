using OSKIDemo.Interfaces;
using OSKIDemo.Models.ViewModels;

namespace OSKIDemo.Services;

public class TestService : ITestService
{

    private readonly IUserRepository _userRepository;
    private readonly ITestRepository _testRepository;
    public TestService(ITestRepository testRepository, IUserRepository userService)
    {
        _testRepository = testRepository;
        _userRepository = userService;
    }

    public async Task<IEnumerable<TestGeneralViewModel>> GetTestsOwnedByUserAsync(Guid userId)
    {
        var possibleUser = await _userRepository.GetUserAsync(userId);

        if (possibleUser == null)
            throw new NullReferenceException("User doesnt exist in database!");

        var userTests = await _testRepository.GetTestsOwnedByUserAsync(userId);

        return userTests;
    }

    public async Task<TestSpecificViewModel> GetTestByIdAsync(Guid testId)
    {      
        var test = await _testRepository.GetTestByIdAsync(testId);

        if (test == null) 
            throw new NullReferenceException("There is no such test in database!");

        return test;
    }

    public async Task PassTestAsync(PassTestViewModel passTestViewModel)
    {
        var userTest = await _testRepository.GetUserTestAsync(passTestViewModel.TestId, passTestViewModel.UserId);

        if (userTest == null || userTest.IsCompleted) 
            throw new NullReferenceException("Can`t find incompleted test in db!");

        await _testRepository.PassTestAsync(userTest, passTestViewModel.AnswerIds);
    }

    public async Task<int> GetMarkForTest(Guid testId,Guid userId)
    {
        var userTest =  await _testRepository.GetUserTestAsync(testId, userId);

        if (userTest is null && !userTest.IsCompleted)
            throw new NullReferenceException("Can`t find completed user test in database!");

        return userTest.Mark;
    }
}
