﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Infrastructure.DI.Abstract;

namespace DAL.Infrastructure.DI.Implementation
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        private readonly NorthwindContext _context;
        public DbSet<TEntity> Table { get; }
        protected RepositoryBase(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Table = _context.Set<TEntity>();
        }
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
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred updating the database", ex);
            }
        }
    }
}

