using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Commands.Entry.GetEntryFav;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Commands.Entry.GetEntryFav
{
    public class GetEntryUserFavCommandHandler : IRequestHandler<GetEntryUserFavCommandRequest, GetEntryUserFavCommandResponse>
    {
        private readonly IEntryFavoriteRepository repository;

        public GetEntryUserFavCommandHandler(IEntryFavoriteRepository repository)
        {
            this.repository = repository;
        }
        public Task<GetEntryUserFavCommandResponse> Handle(GetEntryUserFavCommandRequest request, CancellationToken cancellationToken)
        {
            var entryFav=repository.Where(x => x.UserId == request.UserId && x.EntryId == request.EntryId).ToList();
            if (entryFav.Count == 0)
                return Task.FromResult(new GetEntryUserFavCommandResponse { IsFav = false });
            return Task.FromResult(new GetEntryUserFavCommandResponse { IsFav = true });
        }
    }
}
