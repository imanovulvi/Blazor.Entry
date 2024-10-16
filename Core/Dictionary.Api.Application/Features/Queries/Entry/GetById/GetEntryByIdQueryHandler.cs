using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Queries.Entry.GetById;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Queries.Entry.GetById
{
    public class GetEntryByIdQueryHandler : IRequestHandler<GetEntryByIdQueryRequest, GetEntryByIdQueryResponse>
    {
        private readonly IEntryRepository repository;

        public GetEntryByIdQueryHandler(IEntryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetEntryByIdQueryResponse> Handle(GetEntryByIdQueryRequest request, CancellationToken cancellationToken)
        {

            var entrys = await repository.AsQueryable()
                .AsNoTracking()

                   .Include(x => x.EntryFavorites)
                   .Include(x => x.EntryVotes)
                   .ThenInclude(vote => vote.User)
                   .OrderBy(x => x.Subject)
                         .FirstOrDefaultAsync(x => x.Id == request.Id);


            return new GetEntryByIdQueryResponse {
                Id = entrys.Id,
                Subject = entrys.Subject,
                Content = entrys.Content,
                UserId = entrys.UserId,
                UpCountVotes = entrys.EntryVotes.Count(x => (int)x.VoteType == 1),
                DownCountVotes = entrys.EntryVotes.Count(x => (int)x.VoteType == -1),

                CountFavorites = entrys.EntryFavorites.Count,
                User = entrys.User



            };
        }
    }
}
