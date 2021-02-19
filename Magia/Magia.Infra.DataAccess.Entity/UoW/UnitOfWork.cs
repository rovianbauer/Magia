using Magia.Domain.Core.Notification;
using Magia.Domain.Core.UoW.Interfaces;
using Magia.Infra.DataAccess.Entity.AgendamentoContext;
using System;
using System.Transactions;

namespace Magia.Infra.DataAccess.Entity.UoW
{
    public class UnitOfWork
          : IUnitOfWork
    {
        private TransactionScope Transaction;
        private readonly AgendamentoDbContext _agendamentoDbContext;
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        public UnitOfWork(AgendamentoDbContext agendamentoDbContext, IDomainNotificationHandler domainNotificationHandler)
        {
            _agendamentoDbContext = agendamentoDbContext;
            _domainNotificationHandler = domainNotificationHandler;
        }

        public void Commit()
        {
            if (!_domainNotificationHandler.HasNotifications)
            {
                try
                {
                    _agendamentoDbContext.SaveChanges();
                }
                finally
                {
                    Transaction?.Dispose();
                    OpenTransaction();
                }
            }
        }

        public void OpenTransaction()
        {
            Transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled);
        }

        public void Dispose()
        {
            Transaction?.Dispose();

            //contexts
            _agendamentoDbContext.Dispose();


            GC.SuppressFinalize(this);
        }
    }
}
