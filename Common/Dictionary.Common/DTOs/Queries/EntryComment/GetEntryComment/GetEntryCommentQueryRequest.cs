using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.EntryComment.GetEntryComment
{
    public class GetEntryCommentQueryRequest : IRequest<List<GetEntryCommentQueryResponse>>
    {
        public int EntryId { get; set; }
    }
}
