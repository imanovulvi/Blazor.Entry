using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Commands.Entry.DeleteVote;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Commands.Entry.DeleteVote
{
    public class EntryVoteDeleteCommandHandler : IRequestHandler<EntryVoteDeleteCommandRequest>
    {
        private readonly IEntryVoteRepository repository;


        public EntryVoteDeleteCommandHandler(IEntryVoteRepository repository)
        {
            this.repository = repository;

        }
        public async Task Handle(EntryVoteDeleteCommandRequest request, CancellationToken cancellationToken)
        {
          var vo=await  repository.AsQueryable().FirstOrDefaultAsync(x => x.EntryId == request.EntryId && x.UserId == request.UserId);
            if(vo is not null)
            await repository.DeleteAsync(vo.Id);
        }
    }
}
