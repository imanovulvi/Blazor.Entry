using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.Entry.DeleteVote
{
    public class EntryVoteDeleteCommandRequest : IRequest
    {
        public int UserId { get; set; }
        public int EntryId { get; set; }
    }
}
