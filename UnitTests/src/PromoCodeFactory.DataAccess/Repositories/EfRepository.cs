﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Base;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class EFRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, TEntity<TId>
        where TId : struct
    {
        protected readonly DataContext _context;
        public EFRepository(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();
            return await query.ToListAsync();
        }
        public virtual async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id).AsTask();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(TId id, TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(TId id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}
