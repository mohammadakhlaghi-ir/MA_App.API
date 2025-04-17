using AutoMapper;
using MA_App.Application.Users.DTOs;
using MA_App.Application.Users.Queries;
using MA_App.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.Users.Handlers
{
    public class GetAllUsersHandler(IUserRepository repository, IMapper mapper) 
        : IRequestHandler<GetAllUsersQuery,List<UserDto>>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
