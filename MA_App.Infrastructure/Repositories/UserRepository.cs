using MA_App.Domain.Entities;
using MA_App.Domain.Interfaces;
using MA_App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
