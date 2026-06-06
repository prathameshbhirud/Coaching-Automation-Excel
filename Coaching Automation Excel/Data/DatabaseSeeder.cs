using BCrypt.Net;
using CoachingAutomationExcel.Entities;

namespace CoachingAutomationExcel.Data;

public static class DatabaseSeeder
{
    public static void SeedUsers(CoachingDbContext db)
    {
        if (db.Users.Any())
            return;

        db.Users.Add(new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = "Admin"
            });

        db.SaveChanges();
    }
}