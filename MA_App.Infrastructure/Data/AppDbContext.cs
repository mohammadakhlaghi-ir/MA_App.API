using MA_App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<AppInfo> AppInfos => Set<AppInfo>();
        public DbSet<Layout> Layouts => Set<Layout>();
        public DbSet<SectionLayoutType> SectionLayoutTypes => Set<SectionLayoutType>();
        public DbSet<SectionLayout> SectionLayouts => Set<SectionLayout>();
        public DbSet<ItemLayoutType> ItemLayoutTypes => Set<ItemLayoutType>();
        public DbSet<SectionItemLayout> SectionItemLayouts => Set<SectionItemLayout>();
    }
}
