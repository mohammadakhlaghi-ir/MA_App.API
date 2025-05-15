using FluentValidation.AspNetCore;
using MA_App.Application.AppInfos;
using MA_App.Application.AppInfos.Queries;
using MA_App.Application.Common;
using MA_App.Application.Common.Mappings;
using MA_App.Application.Users.Queries;
using MA_App.Domain.Entities;
using MA_App.Domain.Interfaces;
using MA_App.Infrastructure.Common;
using MA_App.Infrastructure.Data;
using MA_App.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Async(a => a.File("Logs/error-log.txt", rollingInterval: RollingInterval.Day))
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting up the application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services.AddControllers();
    builder.Services.AddOpenApi();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<DbSeeder>();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            policy => policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
    });

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(5024);
    });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();
    app.UseCors("AllowAll");
    app.UseAuthorization();
    app.MapControllers();
    app.UseStaticFiles();

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var seeder = services.GetRequiredService<DbSeeder>();
        await seeder.SeedAsync();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred during DB seeding");
    }

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start correctly");
}
finally
{
    Log.CloseAndFlush();
}
