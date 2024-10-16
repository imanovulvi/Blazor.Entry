using EF=Dictionary.Api.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.Get
{
    public class GetEntryContent
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public EF::User User { get; set; }


        public bool IsFavorite { get; set; }
        public int CountFavorites { get; set; }
        public int  UpCountVotes { get; set; }
        public int  DownCountVotes { get; set; }
        public int IsYourVoteType { get; set; }


    }
}
