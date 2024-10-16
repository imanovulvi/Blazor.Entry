using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Persistence.Concret
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DictionaryDbContext context;
        public DbSet<TEntity> Table { get; set; }

        public GenericRepository(DictionaryDbContext context)
        {
            this.context = context;
            Table=context.Set<TEntity>();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
           await Table.AddAsync(entity);
            return (await context.SaveChangesAsync())>0;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var entity = await Table.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            Table.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
         return await   Table.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
          return await   context.SaveChangesAsync()>0;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return Table.Where(expression);
         
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return Table.AsQueryable();
        }
    }
}
