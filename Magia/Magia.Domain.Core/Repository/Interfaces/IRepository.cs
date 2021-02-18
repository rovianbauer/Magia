using Magia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Magia.Domain.Core.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : BaseEntity<TKey>
    {
        Task InsereAsync(TEntity obj);
        Task<TEntity> ObtemPorIdAsync(TKey id);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
