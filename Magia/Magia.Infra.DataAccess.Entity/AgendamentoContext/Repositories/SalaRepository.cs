using Magia.Domain.AgendamentoContext.Entities;
using Magia.Domain.AgendamentoContext.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Magia.Infra.DataAccess.Entity.AgendamentoContext.Repositories
{
    public class SalaRepository
        : BaseRepository<SalaEntity, Guid>, ISalaRepository
    {
        public SalaRepository(AgendamentoDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<SalaEntity>> BuscarAsync(Expression<Func<SalaEntity, bool>> predicate)
        {
            return this.DbSet
                .Where(predicate);
        }

        public override async Task<SalaEntity> ObtemPorIdAsync(Guid id)
        {
            return this.DbSet
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
