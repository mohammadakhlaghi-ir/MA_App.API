using AutoMapper;
using MA_App.Application.AppInfos.DTOs;
using MA_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.Common.Mappings
{
    public class AppInfoProfile : Profile
    {
        public AppInfoProfile()
        {
            CreateMap<AppInfo, AppInfoDto>();
        }
    }
}
