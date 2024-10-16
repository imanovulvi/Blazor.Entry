using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using EF = Dictionary.Api.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.Common.DTOs.Commands.Entry.Create;

namespace Dictionary.Api.Application.Features.Commands.Entry.Create
{
    public class EntryCreateCommandHandler : IRequestHandler<EntryCreateCommandReuqest>
    {
        private readonly IEntryRepository repository;
        private readonly IMapper mapper;

        public EntryCreateCommandHandler(IEntryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Handle(EntryCreateCommandReuqest request, CancellationToken cancellationToken)
        {
           await  repository.AddAsync(mapper.Map<EF::Entry>(request));
        }
    }
}
