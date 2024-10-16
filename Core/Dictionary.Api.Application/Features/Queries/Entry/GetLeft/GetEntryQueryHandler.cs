using AutoMapper;
using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Queries.Entry.GetLeft;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Queries.Entry.GetLeft
{
    public class GetEntryQueryHandler : IRequestHandler<GetEntrysQueryRequest, List<GetEntryQueryResponse>>
    {
        private readonly IMapper mapper;
        private readonly IEntryRepository repository;

        public GetEntryQueryHandler(IMapper mapper,IEntryRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
      
     async   Task<List<GetEntryQueryResponse>> IRequestHandler<GetEntrysQueryRequest, List<GetEntryQueryResponse>>.Handle(GetEntrysQueryRequest request, CancellationToken cancellationToken)
        {
            var query = repository.AsQueryable();
            if (request.Today)
                query = repository.Where(x => x.CreateDate >= DateTime.UtcNow);

           var entrys= await query.Include(x => x.EntryComments)
                .OrderBy(x => x.Id)
                .Take(request.Count)
                .ToListAsync();
            List<GetEntryQueryResponse> result = new List<GetEntryQueryResponse>();
            foreach (var item in entrys)
            {
                
                result.Add(
                    new GetEntryQueryResponse() 
                    {
                    Id = item.Id,
                    Subject= item.Subject,
                    CountComment= item.EntryComments.Count
                    }
                    );
            }
            return result;
        }
    }
}
