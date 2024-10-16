using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Common.DTOs.Commands.Entry.CreateVote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Commands.Entry.CreateVote
{
    public class EntryVoteCreateCommandHandler : IRequestHandler<EntryVoteCreateCommandReuqest>
    {
        private readonly IEntryVoteRepository repository;
        private readonly IMapper mapper;

        public EntryVoteCreateCommandHandler(IEntryVoteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Handle(EntryVoteCreateCommandReuqest request, CancellationToken cancellationToken)
        {
            await repository.AddAsync(mapper.Map<EntryVote>(request));
        }
    }
}
