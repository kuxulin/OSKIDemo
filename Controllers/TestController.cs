using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSKIDemo.Interfaces;
using OSKIDemo.Models.ViewModels;

namespace OSKIDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;
    public TestController(ITestService testService)
    {
        _testService = testService;
    }
    [HttpGet("user-owned-tests")]
    public async Task<IActionResult> GetTestsOwnedByUser(Guid userId)
    {
        var tests =  await _testService.GetTestsOwnedByUserAsync(userId);
        return Ok(tests);
    }

    [HttpGet("test")]
    public async Task<IActionResult> GetTestById(Guid testId)
    {
        var test = await _testService.GetTestByIdAsync(testId);
        return Ok(test);
    }

    [HttpPost("pass-test")]
    public async Task<IActionResult> PassTest(PassTestViewModel passTestViewModel)
    {
        await _testService.PassTestAsync(passTestViewModel);
        return Ok("Test was successfully passed");
    }

    [HttpGet("mark")]
    public async Task<IActionResult> GetMarkForTest(Guid testId,Guid userId)
    {
        var mark = await _testService.GetMarkForTest(testId, userId);
        return Ok(mark);
    }
}
