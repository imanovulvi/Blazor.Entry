using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Domain.Entitys
{
    public class EntryComment:BaseEntity
    {
        public string Content { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Entry")]
        public int EntryId { get; set; }
        public virtual Entry Entry { get; set; }
    }
}
