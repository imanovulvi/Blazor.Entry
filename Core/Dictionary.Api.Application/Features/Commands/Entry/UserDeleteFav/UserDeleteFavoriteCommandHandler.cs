using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Commands.Entry.UserDeleteFav;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Commands.Entry.UserDeleteFav
{
    public class UserDeleteFavoriteCommandHandler : IRequestHandler<UserDeleteFavoriteCommandRequest>
    {
        private readonly IEntryFavoriteRepository repository;


        public UserDeleteFavoriteCommandHandler(IEntryFavoriteRepository repository)
        {
            this.repository = repository;

        }
        public async Task Handle(UserDeleteFavoriteCommandRequest request, CancellationToken cancellationToken)
        {
          var fav=  await  repository.AsQueryable().FirstOrDefaultAsync(x => x.UserId == request.UserId && x.EntryId == request.EntryId);
           await  repository.DeleteAsync(fav.Id);
        }
    }
}
