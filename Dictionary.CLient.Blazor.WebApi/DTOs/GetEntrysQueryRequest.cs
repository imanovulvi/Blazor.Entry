
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.GetLeft
{
    public class GetEntrysQueryRequest 
    {
        public bool Today { get; set; }
        public int Count { get; set; } = 100;

    }
}
