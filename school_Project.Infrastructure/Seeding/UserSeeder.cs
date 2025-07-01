using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities.Identity;

namespace school_Project.Infrastructure.Seeding
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<Users> _usermanager)
        {
            var userCount = await _usermanager.Users.CountAsync();
            if (userCount <= 0)
            {
                var defaultuser = new Users()
                {
                    UserName = "admin",
                    Email = "admin123@gmail.com",
                    FullName = "HighSchool",
                    PhoneNumber = "123456",
                    Country = "Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                await _usermanager.CreateAsync(defaultuser, "M123_m");
                await _usermanager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}
