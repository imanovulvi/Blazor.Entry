using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using EF = Dictionary.Api.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.Common.DTOs.Commands.User.Create;

namespace Dictionary.Api.Application.Features.Commands.User.Create
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommandRequest>
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserCreateCommandHandler(IUserRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task Handle(UserCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = repository.Where(x => x.Email == request.Email).ToList();
            if (user.Count>0)
                throw new Exception("Tekrar Email ola bilmez.");

            await repository.AddAsync(mapper.Map<EF.User>(request));
        }
    }
}
