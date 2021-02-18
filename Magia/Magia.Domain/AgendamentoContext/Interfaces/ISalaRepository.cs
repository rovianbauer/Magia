using Magia.Domain.AgendamentoContext.Entities;
using Magia.Domain.Core.Repository.Interfaces;
using System;

namespace Magia.Domain.AgendamentoContext.Interfaces
{
    public interface ISalaRepository : IRepository<SalaEntity, Guid>
    {
    }
}
