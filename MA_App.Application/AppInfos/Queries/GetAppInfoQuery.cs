using MA_App.Application.AppInfos.DTOs;
using MA_App.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.AppInfos.Queries
{
    public record GetAppInfoQuery : IRequest<AppInfoDto>;
}
