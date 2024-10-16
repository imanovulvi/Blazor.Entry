using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.User.Login
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
