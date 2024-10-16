using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.User.Get
{
    public class GetUserDetailQueryRequest:IRequest<GetUserDetailQueryResponse>
    {
        public int UserId { get; set; }
    }
}
