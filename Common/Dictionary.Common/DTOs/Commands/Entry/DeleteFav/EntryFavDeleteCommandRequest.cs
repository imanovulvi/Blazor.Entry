using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.Entry.DeleteFav
{
    public class EntryFavDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
