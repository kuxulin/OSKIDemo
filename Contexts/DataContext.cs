using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OSKIDemo.Models;

namespace OSKIDemo.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    public DataContext(DbContextOptions options) : base(options) { }

    DbSet<Test> Tests { get; set; }
    DbSet<Question> Questions { get; set; }
    DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserTest>()
            .HasKey(ut => new { ut.UserId, ut.TestId });

        builder.Entity<UserTest>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTests)
            .HasForeignKey(ut => ut.UserId);

        builder.Entity<UserTest>()
            .HasOne(ut => ut.Test)
            .WithMany(t => t.UserTests)
            .HasForeignKey(ut => ut.TestId);

        builder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question);
    }
}