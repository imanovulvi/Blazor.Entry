using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Domain.Entitys
{
    public class EntryFavorite:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int EntryId { get; set; }
        public Entry Entry { get; set; }
    }
}
