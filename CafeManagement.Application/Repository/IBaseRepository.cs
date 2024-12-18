﻿using CafeManagement.Domain.Common;
using CafeManagement.Domain.Entities;
using System.Linq.Expressions;

namespace CafeManagement.Application.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        void Delete(Guid Id);

        Task<T> Get(Guid id, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes);
        Task<T> GetWithoutChangeTracking(Guid id, CancellationToken cancellationToken);

        Task<List<T>> GetAll(CancellationToken cancellationToken);

        Task<List<T>> GetAllWithoutChangeTracking(CancellationToken cancellationToken);

        Task<List<T>> GetAllNoTracking(params Expression<Func<T, object>>[] includes);

        Task<bool> Any(Guid id, CancellationToken cancellationToken);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<List<T>> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    }
}
