using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using EF = Dictionary.Api.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.Common.DTOs.Commands.EntryComment.Create;

namespace Dictionary.Api.Application.Features.Commands.EntryComment.Create
{
    public class EntryCommentCommandHandler : IRequestHandler<EntryCommentCommandRequest>
    {
        private readonly IEntryCommentRepository repository;
        private readonly IMapper mapper;

        public EntryCommentCommandHandler(IEntryCommentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Handle(EntryCommentCommandRequest request, CancellationToken cancellationToken)
        {
         await    repository.AddAsync(mapper.Map<EF.EntryComment>(request));
        }
    }
}
