using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Commands.User.ChangePassword;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Commands.User.ChangePassword
{
    public class UserChangePasswordCommadnHandler : IRequestHandler<UserChangePasswordCommandRequest>
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserChangePasswordCommadnHandler(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Handle(UserChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var user=(repository.Where(x => x.Email == request.Email && x.Password == request.OldPassword).ToList());
            if (user.Count == 0)
                throw new Exception("Ble user yoxdu");
            user[0].Password=request.NewPassword;

           await  repository.UpdateAsync(user[0]);
        }
    }
}
