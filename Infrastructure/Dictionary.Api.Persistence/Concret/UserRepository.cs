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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DictionaryDbContext context) : base(context)
        {
        }
    }
}
