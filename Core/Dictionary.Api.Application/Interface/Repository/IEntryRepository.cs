using EF=Dictionary.Api.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Interface.Repository
{
    public interface IEntryRepository : IGenericRepository<EF.Entry>
    {
    }
}
