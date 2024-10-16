using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Domain.Entitys
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public ICollection<EntryComment> EntryComments { get; set; }
        public ICollection<EntryFavorite> EntryFavorites { get; set; }
        public ICollection<EntryVote> EntryVotes { get; set; }

        public int EmailConfigurationId { get; set; }
        public EmailConfiguration EmailConfiguration { get; set; }
    }
}
