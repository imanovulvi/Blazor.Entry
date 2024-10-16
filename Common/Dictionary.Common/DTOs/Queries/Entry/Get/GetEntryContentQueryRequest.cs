using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.Get
{
    public class GetEntryContentQueryRequest:IRequest<GetEntryContentQueryResponse>
    {
        public int CurrenPage;
        public int Page {
            get
            {
                return (CurrenPage * PageSize)-PageSize;
            }
            set
            {
                CurrenPage = value;
            }
        }
        public int PageSize { get; set; }

        public int UserId { get; set; } = 0;
    }
}
