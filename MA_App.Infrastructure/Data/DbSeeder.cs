using MA_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Infrastructure.Data
{
    public class DbSeeder(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task SeedAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.AddRange(
                    new User
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        FirstName = "first name",
                        LastName = "last name",
                        Password = "25d55ad283aa400af464c76d713c07ad",
                        Created = DateTime.Now,
                        DateOfBirth = DateTime.Now,
                        Image = "default.jpg",
                        Description = "admin",
                        IsLock = false,
                        IsDeleted = false,
                    }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.AppInfos.Any())
            {
                _context.AppInfos.AddRange(
                    new AppInfo
                    {
                        Description = "MA_App ",
                        Created = DateTime.Now,
                        Favicon = "favicon.ico",
                        Language = "en",
                        Logo = "logo.svg",
                        Title = "MA_App",
                        Version = "0.1",
                    }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}
