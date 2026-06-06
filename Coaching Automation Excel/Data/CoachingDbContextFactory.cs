using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoachingAutomationExcel.Data;

public class CoachingDbContextFactory: IDesignTimeDbContextFactory<CoachingDbContext>
{
    public CoachingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CoachingDbContext>();

        optionsBuilder.UseSqlite("Data Source=coaching.db");

        return new CoachingDbContext(optionsBuilder.Options);
    }
}