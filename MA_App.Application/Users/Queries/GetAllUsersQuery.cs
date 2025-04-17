using MA_App.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MA_App.Application.Users.Queries
{
    public record GetAllUsersQuery : IRequest<List<UserDto>>;
}
