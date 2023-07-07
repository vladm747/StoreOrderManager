using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities.Base;
using DAL.Infrastructure.DI.Abstract;

namespace DAL.Infrastructure.DI.Implementation
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public NorthwindContext Context { get; }
        public DbSet<TEntity> Table { get; }
        protected RepositoryBase(NorthwindContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Table = Context.Set<TEntity>();
        }
        protected RepositoryBase(DbContextOptions<NorthwindContext> options) : this(new NorthwindContext(options)) { }
      
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<TEntity?> FindAsync(TKey key)
        {
            return await Table.FindAsync(key);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            await SaveChangesAsync();
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred updating the database", ex);
            }
        }
    }
}

