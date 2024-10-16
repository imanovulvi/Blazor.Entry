using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.Get
{
    public class PageInfo
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
       
        public int PageTotal { get; set; }
        public int CurrenPage { get; set; }
    }
}
