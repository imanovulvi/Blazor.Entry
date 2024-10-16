using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Queries.Entry.Get;
using Dictionary.Common.DTOs.Queries.Entry.Search;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Queries.Entry.Serach
{
    public class EntrySearchQueryHandler : IRequestHandler<EntrySearchQueryRequest, List<EntrySearchQueryResponse>>
    {
        private readonly IEntryRepository repository;

        public EntrySearchQueryHandler(IEntryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<EntrySearchQueryResponse>> Handle(EntrySearchQueryRequest request, CancellationToken cancellationToken)
        {
            var query = await repository.AsQueryable()
                   .Include(x => x.EntryFavorites)
                   .Include(x => x.EntryVotes)
                   .Include(x => x.User)
                   .OrderBy(x => x.UserId)
                    .Where(x => x.Subject.Contains(request.SerachText))
                    .ToListAsync();

            List<EntrySearchQueryResponse> result = new List<EntrySearchQueryResponse>();
            foreach (var item in query)
            {
                result.Add(
                    new EntrySearchQueryResponse()
                    {
                        Id = item.Id,
                        Subject = item.Subject,
                        Content = item.Content,
                        UserId = item.UserId,
                        CountVotes = item.EntryVotes.Count,
                        CountFavorites = item.EntryFavorites.Count
               
                    }

                    );
            }
            return result;
        }
    }
}
