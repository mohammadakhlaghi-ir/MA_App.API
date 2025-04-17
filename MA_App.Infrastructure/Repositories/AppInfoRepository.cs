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
    public class AppInfoRepository(AppDbContext context) : IAppInfoRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<AppInfo> GetAppInfoAsync()
        {
            return await _context.AppInfos.FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("AppInfo record not found.");
        }
    }
}
