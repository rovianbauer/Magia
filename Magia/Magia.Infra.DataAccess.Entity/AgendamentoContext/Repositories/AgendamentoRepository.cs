using Magia.Domain.AgendamentoContext.Entities;
using Magia.Domain.AgendamentoContext.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Magia.Infra.DataAccess.Entity.AgendamentoContext.Repositories
{
    public class AgendamentoRepository
        : BaseRepository<AgendamentoEntity, Guid>, IAgendamentoRepository
    {
        public AgendamentoRepository(AgendamentoDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<AgendamentoEntity>> BuscarAsync(Expression<Func<AgendamentoEntity, bool>> predicate)
        {
            return this.DbSet
               .Where(predicate);
        }

        public override async Task<AgendamentoEntity> ObtemPorIdAsync(Guid id)
        {
            return this.DbSet
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
