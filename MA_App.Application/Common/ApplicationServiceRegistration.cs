using FluentValidation;
using MA_App.Application.AppInfos.Queries;
using MA_App.Application.AppInfos.Validators;
using MA_App.Application.Common.Mappings;
using MA_App.Application.Users.Queries;
using MA_App.Application.Users.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.Common
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Users
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining<GetAllUsersQuery>());
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddValidatorsFromAssemblyContaining<UserDtoValidator>();
            #endregion

            #region AppInfo
            services.AddMediatR(cfg =>
              cfg.RegisterServicesFromAssemblyContaining<GetAppInfoQuery>());
            services.AddAutoMapper(typeof(AppInfoProfile).Assembly);
            services.AddValidatorsFromAssemblyContaining<AppInfoDtoValidator>();
            #endregion

            return services;
        }
    }
}
