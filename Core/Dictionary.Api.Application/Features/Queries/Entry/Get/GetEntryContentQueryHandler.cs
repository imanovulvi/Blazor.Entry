using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Common.DTOs.Queries.Entry.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Queries.Entry.Get
{
    public class GetEntryContentQueryHandler : IRequestHandler<GetEntryContentQueryRequest, GetEntryContentQueryResponse>
    {
        private readonly IEntryRepository repository;

        public GetEntryContentQueryHandler(IEntryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetEntryContentQueryResponse> Handle(GetEntryContentQueryRequest request, CancellationToken cancellationToken)
        {
            var entrys = await repository.AsQueryable()
                .AsNoTracking()
                   .Include(x => x.EntryFavorites)
                
                   .Include(x => x.EntryVotes)
                   .ThenInclude(vote => vote.User)

                   .OrderBy(x => x.Subject)
                    
                    .ToListAsync();
           

           var entrysPage= entrys.Skip(request.Page)
                    .Take(request.PageSize);
            List<GetEntryContent> getEntryContent = new List<GetEntryContent>();
            
            foreach (var item in entrysPage)
            {
              

                
                bool IsFav = false;
                foreach (var itemFav in item.EntryFavorites)
                {
                    if (request.UserId ==itemFav.UserId)
                    {
                        IsFav = true;
                    }
                    
                }
                var vote = item.EntryVotes;
                var aaaa= vote.Count == 0 ? 0 : (int)vote.FirstOrDefault(x => x.User.Id == request.UserId).VoteType;
                getEntryContent.Add(
                    new GetEntryContent()
                    {
                        Id = item.Id,
                        Subject = item.Subject,
                        Content = item.Content,
                        UserId = item.UserId,
                        UpCountVotes = item.EntryVotes.Count(x => (int)x.VoteType == 1),
                        DownCountVotes = item.EntryVotes.Count(x => (int)x.VoteType == -1),

                        CountFavorites = item.EntryFavorites.Count,
                        User = item.User,
                        IsFavorite = IsFav,
                        IsYourVoteType = vote.Count==0? 0 : (int)vote.FirstOrDefault(x => x.User.Id == request.UserId).VoteType
                    }

                    );
            }

            

            PageInfo pageInfo = new PageInfo
            {
                PageSize = request.PageSize,
                PageTotal = entrys.Count,
                CurrenPage=request.CurrenPage

            };
            return new GetEntryContentQueryResponse
            {
                GetEntryContent = getEntryContent,
                PageInfo = pageInfo
            };
        }

    }
}
