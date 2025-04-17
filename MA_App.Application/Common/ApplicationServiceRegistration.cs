using MA_App.Application.AppInfos.Queries;
using MA_App.Application.Common.Mappings;
using MA_App.Application.Users.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.Common
{
    namespace MA_App.Application
    {
        public static class ApplicationServiceRegistration
        {
            public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            {
                services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssemblyContaining<GetAllUsersQuery>());

                services.AddMediatR(cfg =>
                  cfg.RegisterServicesFromAssemblyContaining<GetAppInfoQuery>());

                services.AddAutoMapper(typeof(UserProfile).Assembly);

                services.AddAutoMapper(typeof(AppInfoProfile).Assembly);

                return services;
            }
        }
    }

}
