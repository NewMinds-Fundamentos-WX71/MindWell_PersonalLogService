using Microsoft.EntityFrameworkCore;
using MindWell_PersonalLogService.Shared.Extensions;

namespace MindWell_PersonalLogService.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<PersonalLog.Domain.Models.PersonalLog> PersonalLogs { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<PersonalLog.Domain.Models.PersonalLog>().ToTable("PersonalLogs");
        builder.Entity<PersonalLog.Domain.Models.PersonalLog>().HasKey(p => p.Id);
        builder.Entity<PersonalLog.Domain.Models.PersonalLog>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PersonalLog.Domain.Models.PersonalLog>().Property(p => p.Thought).IsRequired();
        builder.Entity<PersonalLog.Domain.Models.PersonalLog>().Property(p => p.Date).IsRequired();
        builder.Entity<PersonalLog.Domain.Models.PersonalLog>().Property(p => p.Users_Id).IsRequired();

        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}