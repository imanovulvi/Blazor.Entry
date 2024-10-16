using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.Get
{
    public class GetEntryContentQueryResponse
    {
        public List<GetEntryContent> GetEntryContent { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
