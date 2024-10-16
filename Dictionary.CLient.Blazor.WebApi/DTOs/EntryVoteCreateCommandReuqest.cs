using Dictionary.Api.Domain.Entitys;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.Entry.CreateVote
{
    public class EntryVoteCreateCommandReuqest 
    {
        public VoteType VoteType { get; set; }
        public int EntryId { get; set; }

        public int UserId { get; set; }

    }
    public enum VoteType
    {
        None = -1,
        Down = 0,
        Up = 1
    }
}
