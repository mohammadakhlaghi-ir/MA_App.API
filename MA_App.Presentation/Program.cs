using MA_App.Application.Common.Mappings;
using MA_App.Application.Users.Queries;
using MA_App.Domain.Entities;
using MA_App.Domain.Interfaces;
using MA_App.Infrastructure.Data;
using MA_App.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region User Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllUsersQuery>());
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbSeeder>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var seeder = services.GetRequiredService<DbSeeder>();
await seeder.SeedAsync();

app.Run();