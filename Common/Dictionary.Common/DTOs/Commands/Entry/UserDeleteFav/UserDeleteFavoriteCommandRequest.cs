using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.Entry.UserDeleteFav
{
    public class UserDeleteFavoriteCommandRequest:IRequest
    {
        public int UserId { get; set; }
        public int EntryId { get; set; }
    }
}
