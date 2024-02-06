using OSKIDemo.Models.ViewModels;

namespace OSKIDemo.Interfaces;

public interface ITestService
{
    Task<IEnumerable<TestGeneralViewModel>> GetTestsOwnedByUserAsync(Guid userId);
    Task<TestSpecificViewModel> GetTestByIdAsync(Guid testId);
    Task PassTestAsync(PassTestViewModel passTestViewModel);
    Task<int> GetMarkForTest(Guid testId, Guid userId);
}
