using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.GetById
{
    public class GetEntryByIdQueryRequest:IRequest<GetEntryByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
