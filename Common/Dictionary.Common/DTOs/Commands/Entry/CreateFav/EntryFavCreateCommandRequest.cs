using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.Entry.CreateFav
{
    public class EntryFavCreateCommandRequest : IRequest
    {
        public int UserId { get; set; }

        public int EntryId { get; set; }
    }
}
