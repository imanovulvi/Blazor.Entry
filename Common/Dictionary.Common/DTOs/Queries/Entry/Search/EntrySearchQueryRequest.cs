﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Queries.Entry.Search
{
    public class EntrySearchQueryRequest:IRequest<List<EntrySearchQueryResponse>>
    {
        public string SerachText { get; set; }
    }
}
