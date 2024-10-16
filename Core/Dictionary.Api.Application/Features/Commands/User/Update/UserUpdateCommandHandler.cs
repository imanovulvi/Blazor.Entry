using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using EF = Dictionary.Api.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.Common.DTOs.Commands.User.Update;

namespace Dictionary.Api.Application.Features.Commands.User.Update
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandRequest>
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserUpdateCommandHandler(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task Handle(UserUpdateCommandRequest request, CancellationToken cancellationToken)
        {

            var user = repository.Where(x => x.Id == request.Id).ToList();
            if (user.Count == 0)
                throw new Exception("Bele istifadeci yoxdu");
            mapper.Map(request, user[0]);
            await repository.UpdateAsync(user[0]);
          
        }
    }
}
