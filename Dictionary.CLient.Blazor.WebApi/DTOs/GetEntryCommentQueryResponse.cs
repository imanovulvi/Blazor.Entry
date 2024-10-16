using EF=Dictionary.Api.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.EntryComment.GetEntryComment
{
    public class GetEntryCommentQueryResponse
    {
        public int EntryId { get; set; }
        public string Content { get; set; }
        public  EF::User User { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
