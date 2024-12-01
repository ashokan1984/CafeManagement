﻿using CafeManagement.Domain.Common;
using CafeManagement.Persistence.Context;
using CafeManagement.Application.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CafeManagement.Domain.Entities;

namespace CafeManagement.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly CafeManagementDBContext Context;

        public BaseRepository(CafeManagementDBContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            try
            {
                Context.Update(entity);   
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflicts here
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is T)
                    {
                        entry.Reload();
                    }
                }

                // Log the error, return a message, or rethrow to notify caller of conflict
                throw new Exception("The entity you tried to update was modified by another process.");
            }
        }

        public void Delete(T entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }

        public void Delete(Guid Id)
        {
            IQueryable<T> query = Context.Set<T>();
            Context.Remove(query.Single(a => a.ID == Id));
        }


        public virtual Task<T> Get(Guid id, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
        }

        public virtual Task<bool> Any(Guid id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().AnyAsync(x => x.ID == id, cancellationToken);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Context.Set<T>();
            return await query.AnyAsync(predicate);
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.Where(predicate).ToListAsync();
        }

        public virtual Task<T> GetWithoutChangeTracking(Guid id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
        }

        public virtual Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }

        public virtual Task<List<T>> GetAllNoTracking(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            query.AsNoTracking();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToListAsync();
        }

        public virtual Task<List<T>> GetAllWithoutChangeTracking(CancellationToken cancellationToken)
        {
            return Context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefaultAsync();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}