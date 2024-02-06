using OSKIDemo.Models;
using OSKIDemo.Models.ViewModels;

namespace OSKIDemo.Interfaces;

public interface ITestRepository
{
    Task<IEnumerable<TestGeneralViewModel>> GetTestsOwnedByUserAsync(Guid userId);
    Task<TestSpecificViewModel> GetTestByIdAsync(Guid testId);
    Task<UserTest> GetUserTestAsync(Guid testId, Guid userId);
    Task PassTestAsync(UserTest userTest, IEnumerable<Guid> answerIds);
}
