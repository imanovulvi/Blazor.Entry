using Dictionary.Api.Application.Interface.Repository;
using EF=Dictionary.Api.Domain.Entitys;
using Dictionary.Api.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Persistence.Concret
{
    public class EntryRepository : GenericRepository<EF.Entry>, IEntryRepository
    {
        public EntryRepository(DictionaryDbContext context) : base(context)
        {
        }
    }
}
