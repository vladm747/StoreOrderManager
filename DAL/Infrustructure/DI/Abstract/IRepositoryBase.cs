﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrustructure.DI.Abstract
{
    public interface IRepositoryBase<TEntity, TKey>
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity?> GetByKeyAsync(TKey key);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
    }
}
