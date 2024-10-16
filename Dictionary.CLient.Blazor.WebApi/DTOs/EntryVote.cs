using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Common.DTOs.Commands.Entry.CreateVote;

namespace Dictionary.CLient.Blazor.WebApi.DTOs
{
    public class EntryVote 
    {
        public VoteType VoteType { get; set; }
        public int EntryId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
