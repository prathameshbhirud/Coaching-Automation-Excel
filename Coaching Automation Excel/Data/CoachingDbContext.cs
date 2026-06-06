using CoachingAutomationExcel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoachingAutomationExcel.Data;

public class CoachingDbContext: DbContext
{
    public CoachingDbContext(DbContextOptions<CoachingDbContext> options): base(options)
    {
    }

    public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();

    public DbSet<NotificationStatistic> NotificationStatistics => Set<NotificationStatistic>();

    public DbSet<User> Users => Set<User>();
}