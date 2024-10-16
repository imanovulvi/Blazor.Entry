using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using EF = Dictionary.Api.Domain.Entitys;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dictionary.Common.AppClasses;
using System.Security.Cryptography.Xml;
using Dictionary.Common.DTOs.Commands.User.Login;

namespace Dictionary.Api.Application.Features.Commands.User.Login
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public UserLoginCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            TokenGenerate tokenGenerate = new TokenGenerate();

            var user = userRepository.Where(x => x.Email == request.Email && x.Password == request.Password).ToList();
            if (user[0] is null)
                throw new Exception("Password and Email have error");

            UserLoginCommandResponse response = new UserLoginCommandResponse
            {
                Name = user[0].Name,
                Surname = user[0].Surname,
                Email = user[0].Email,
                Token = tokenGenerate.CreateAccessToken(user[0], DateTime.Now.AddDays(1), configuration)

            };

            return Task.FromResult(response);
        }


    }
}
