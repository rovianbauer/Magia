using Magia.Domain.Core.Entities;
using Magia.Domain.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Magia.Infra.DataAccess.Entity.AgendamentoContext.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>
         : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected AgendamentoDbContext Db;
        protected DbSet<TEntity> DbSet;

        protected BaseRepository(AgendamentoDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task InsereAsync(TEntity obj)
        {
            try
            {
                DbSet.Add(obj);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public abstract Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);

        public abstract Task<TEntity> ObtemPorIdAsync(TKey id);

        public void Dispose()
        {
            Db.Dispose();
        }

        //public TEntity AddOrUpdate(TEntity entity)
        //{
        //    var entityEntry = Db.Entry(entity);

        //    var primaryKeyName = entityEntry.Context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
        //        .Select(x => x.Name).Single();

        //    var primaryKeyField = entity.GetType().GetProperty(primaryKeyName);

        //    var t = typeof(TEntity);
        //    if (primaryKeyField == null)
        //    {
        //        throw new Exception($"{t.FullName} does not have a primary key specified. Unable to exec AddOrUpdate call.");
        //    }
        //    var keyVal = primaryKeyField.GetValue(entity);
        //    var dbVal = DbSet.Find(keyVal);

        //    if (dbVal != null)
        //    {
        //        Db.Entry(dbVal).CurrentValues.SetValues(entity);
        //        DbSet.Update(dbVal);

        //        entity = dbVal;
        //    }
        //    else
        //    {
        //        DbSet.Add(entity);
        //    }

        //    return entity;
        //}
    }
}
