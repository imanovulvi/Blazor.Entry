using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.Entry.Create
{
    public class EntryCreateCommandReuqest : IRequest
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }

    }
}
