using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.GetLeft
{
    public class GetEntryQueryResponse
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int CountComment { get; set; }
    }
}
