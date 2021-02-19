using System;

namespace Magia.Domain.Core.UoW.Interfaces
{
    public interface IUnitOfWork
           : IDisposable
    {
        void Commit();
    }
}
