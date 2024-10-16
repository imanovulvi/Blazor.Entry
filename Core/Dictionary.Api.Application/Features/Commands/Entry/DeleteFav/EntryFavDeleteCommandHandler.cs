using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Commands.Entry.DeleteFav;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Commands.Entry.DeleteFav
{
    public class EntryFavDeleteCommandHandler : IRequestHandler<EntryFavDeleteCommandRequest>
    {
        private readonly IEntryFavoriteRepository repository;


        public EntryFavDeleteCommandHandler(IEntryFavoriteRepository repository)
        {
            this.repository = repository;
   
        }
        public async Task Handle(EntryFavDeleteCommandRequest request, CancellationToken cancellationToken)
        {
          await   repository.DeleteAsync(request.Id);
        }
    }
}
