using Microsoft.AspNetCore.Identity;
using OSKIDemo.Data;
using OSKIDemo.Models;

namespace OSKIDemo.Contexts;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var context = services.GetRequiredService<DataContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        context.Database.EnsureCreated();

        if (context.Tests.Any()) return;

        var users = new ApplicationUser[]
        {
                new (){UserName="Maks"},
                new (){UserName="string"},
        };

        var questionArray = new Question[4];
        for (int i = 0; i < 4; i++)
        {
            var question = new Question()
            {
                Text = $"Is it {i + 1} question?"
            };
            questionArray[i] = question;
        }

        foreach (var question in questionArray)
        {
            var answer1 = new Answer()
            {
                Text = "answer(wrong)",
                IsRight = false,
                QuestionId = question.Id

            };
            var answer2 = new Answer()
            {
                Text = "answer(right)",
                IsRight = true,
                QuestionId = question.Id
            };
            question.Answers = new List<Answer>() { answer1, answer2 };
        }

        var test1 = new Test()
        {
            Name = "First",
            Questions = new List<Question>() { questionArray[0], questionArray[1] }
        };

        var test2 = new Test()
        {
            Name = "Second",
            Questions = new List<Question>() { questionArray[2], questionArray[3] }
        };

        foreach (var user in users)
        {
            var userTest1 = new UserTest()
            {
                UserId = user.Id,
                TestId = test1.Id
            };
            var userTest2 = new UserTest()
            {
                UserId = user.Id,
                TestId = test2.Id,
            };
            user.UserTests = new List<UserTest>() { userTest1, userTest2 };
        }

        context.Tests.AddRange(test1, test2);
        await context.SaveChangesAsync();
        await userManager.CreateAsync(users[0], "password");
        await userManager.CreateAsync(users[1], "string");
    }
}
