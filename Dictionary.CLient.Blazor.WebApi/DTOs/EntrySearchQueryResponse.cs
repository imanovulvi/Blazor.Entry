using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.Search
{
    public class EntrySearchQueryResponse
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }


        public int CountFavorites { get; set; }
        public int CountVotes { get; set; }
    }
}
