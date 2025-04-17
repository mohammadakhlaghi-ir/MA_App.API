using MA_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Infrastructure.Data
{
    public class DbSeeder
    {
        private readonly AppDbContext _context;

        public DbSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.AddRange(
                    new User { Name = "Admin", Email = "admin@admin.com" }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}
