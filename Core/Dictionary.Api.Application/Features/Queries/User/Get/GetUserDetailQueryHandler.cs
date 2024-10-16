using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Queries.User.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Queries.User.Get
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQueryRequest, GetUserDetailQueryResponse>
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public GetUserDetailQueryHandler(IUserRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetUserDetailQueryResponse> Handle(GetUserDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var user =await  repository.GetByIdAsync(request.UserId);
          return  mapper.Map<GetUserDetailQueryResponse>(user);
        }
    }
}
