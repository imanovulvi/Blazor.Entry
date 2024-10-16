using Dictionary.Api.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.Entry.CreateVote
{
    public class EntryVoteCreateCommandReuqest : IRequest
    {
        public VoteType VoteType { get; set; }
        public int EntryId { get; set; }

        public int UserId { get; set; }

    }
}
