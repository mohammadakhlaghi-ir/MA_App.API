using AutoMapper;
using MA_App.Application.AppInfos.DTOs;
using MA_App.Application.AppInfos.Queries;
using MA_App.Application.Users.DTOs;
using MA_App.Application.Users.Queries;
using MA_App.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.AppInfos.Handlers
{
    public class GetAppInfoHandler(IAppInfoRepository repository, IMapper mapper)
       : IRequestHandler<GetAppInfoQuery, AppInfoDto>
    {
        private readonly IAppInfoRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<AppInfoDto> Handle(GetAppInfoQuery request, CancellationToken cancellationToken)
        {
            var appInfo = await _repository.GetAppInfoAsync();
            return _mapper.Map<AppInfoDto>(appInfo);
        }
    }
}
