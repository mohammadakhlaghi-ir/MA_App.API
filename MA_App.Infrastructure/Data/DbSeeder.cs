using MA_App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            using var transaction = await _context.Database.BeginTransactionAsync();

            if (!_context.Users.Any())
            {
                _context.Users.AddRange(
                    new User
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        FirstName = "first name",
                        LastName = "last name",
                        Password = "1234",
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
            if (!_context.Layouts.Any())
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Layouts ON");
                _context.Layouts.AddRange(new Layout
                {
                    Created = DateTime.Now,
                    Description = "Main Layout",
                    IsDeleted = false,
                    Main = true,
                    Name = "Main Layout",
                    Id = 1
                });
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Layouts OFF");
            }
            if (!_context.SectionLayoutTypes.Any())
            {
                var sectionLayoutTypes = new[]
                {
                    new SectionLayoutType { Id = 1, Name = "mainHeader", Description = "Main header area" },
                    new SectionLayoutType { Id = 2, Name = "topHeader", Description = "Top header area" },
                    new SectionLayoutType { Id = 3, Name = "bottomHeader", Description = "Bottom header area" },
                    new SectionLayoutType { Id = 4, Name = "mainFooter", Description = "Main footer area" },
                    new SectionLayoutType { Id = 5, Name = "topFooter", Description = "Top footer area" },
                    new SectionLayoutType { Id = 6, Name = "bottomFooter", Description = "Bottom footer area" },
                    new SectionLayoutType { Id = 7, Name = "sideBar", Description = "Sidebar section" }
                };
                _context.SectionLayoutTypes.AddRange(sectionLayoutTypes);
                await _context.SaveChangesAsync();
            }
            if (!_context.SectionLayouts.Any())
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT SectionLayouts ON");

                var sectionLayouts = new[]
                {
                    new SectionLayout {
                        Id = 1 ,
                        LayoutId = 1,
                        MobileVisible = true ,
                        IsDeleted = false,
                        Created = DateTime.Now,
                        Description = "Header of Main Layout",
                        Name = "Header of Main Layout",
                        SectionLayoutTypeId = 1,
                    },
                    new SectionLayout {
                        Id = 2 ,
                        LayoutId = 1,
                        MobileVisible = true ,
                        IsDeleted = false,
                        Created = DateTime.Now,
                        Description = "Sidebar of Main Layout",
                        Name = "Sidebar of Main Layout",
                        SectionLayoutTypeId = 7,
                    },
                    new SectionLayout {
                        Id = 3 ,
                        LayoutId = 1,
                        MobileVisible = true ,
                        IsDeleted = false,
                        Created = DateTime.Now,
                        Description = "Footer of Main Layout",
                        Name = "Footer of Main Layout",
                        SectionLayoutTypeId = 5,
                    },
                };
                _context.SectionLayouts.AddRange(sectionLayouts);
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT SectionLayouts OFF");

            }
            if (!_context.ItemLayoutTypes.Any())
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ItemLayoutTypes ON");

                var itemLayoutTypes = new[]
                {
                    new ItemLayoutType { Id = 1, Name = "menu", Description = "Navigation menu" },
                    new ItemLayoutType { Id = 2, Name = "logo", Description = "Logo" },
                    new ItemLayoutType { Id = 3, Name = "buttonNavigation", Description = "Button for navigation" },
                    new ItemLayoutType { Id = 4, Name = "socialIcons", Description = "Icons for social media" },
                    new ItemLayoutType { Id = 5, Name = "copyRight", Description = "copy right label" },
                };
                _context.ItemLayoutTypes.AddRange(itemLayoutTypes);
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ItemLayoutTypes OFF");

            }
            if (!_context.SectionItemLayouts.Any())
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT SectionItemLayouts ON");

                var sectionItemLayouts = new[]
                {
                    new SectionItemLayout {
                        Id = 1,
                        Created = DateTime.Now ,
                        Description = "Menu of Main Header",
                        IsDeleted = false,
                        ItemLayoutTypeId = 1,
                        SectionLayoutId = 1,
                        MobileVisible = true ,
                    },
                    new SectionItemLayout {
                        Id = 2,
                        Created = DateTime.Now ,
                        Description = "Logo of Main Header",
                        IsDeleted = false,
                        ItemLayoutTypeId = 2,
                        SectionLayoutId = 1,
                        MobileVisible = true ,
                    },
                    new SectionItemLayout {
                        Id = 3,
                        Created = DateTime.Now ,
                        Description = "Social Icons of Main Sidebar",
                        IsDeleted = false,
                        ItemLayoutTypeId = 4,
                        SectionLayoutId = 2,
                        MobileVisible = true ,
                    },
                    new SectionItemLayout {
                        Id = 4,
                        Created = DateTime.Now ,
                        Description = "Copy Right Label of Main Footer",
                        IsDeleted = false,
                        ItemLayoutTypeId = 5,
                        SectionLayoutId = 3,
                        MobileVisible = true ,
                    },
                };
                _context.SectionItemLayouts.AddRange(sectionItemLayouts);
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT SectionItemLayouts OFF");
            }

            await transaction.CommitAsync();
        }
    }
}
