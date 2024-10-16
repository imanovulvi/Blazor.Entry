using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Domain.Entitys
{
    public class Entry:BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<EntryComment> EntryComments { get; set; }

        public ICollection<EntryFavorite> EntryFavorites { get; set; }
        public ICollection<EntryVote> EntryVotes { get; set; }
    
    }
}
