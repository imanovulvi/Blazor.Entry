using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Common.DTOs.Commands.Entry.CreateFav;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Commands.Entry.CreateFav
{
    public class EntryFavCreateCommandHandler : IRequestHandler<EntryFavCreateCommandRequest>
    {
        private readonly IEntryFavoriteRepository repository;
        private readonly IMapper mapper;

        public EntryFavCreateCommandHandler(IEntryFavoriteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Handle(EntryFavCreateCommandRequest request, CancellationToken cancellationToken)
        {
         await   repository.AddAsync(mapper.Map<EntryFavorite>(request));
        }
    }
}
