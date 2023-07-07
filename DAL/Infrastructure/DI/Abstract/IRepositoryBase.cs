using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities.Base;

namespace DAL.Infrastructure.DI.Abstract
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        DbSet<TEntity> Table { get; }
        NorthwindContext Context { get; }
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> FindAsync(TKey key);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
