using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Api.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Persistence.Concret
{
    public class EntryFavoriteRepository : GenericRepository<EntryFavorite>, IEntryFavoriteRepository
    {
        public EntryFavoriteRepository(DictionaryDbContext context) : base(context)
        {
        }
    }
}
