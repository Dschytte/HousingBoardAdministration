using BookingSystemApi.Application.Transaction;
using BookingSystemApi.SqlServerContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace BookingSystemApi.Infrastructure.TransactionHandling.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingSystemDbContext _context;
        private IDbContextTransaction _dbTransaction;

        public UnitOfWork(BookingSystemDbContext context)
        {
            this._context = context;
        }

        void IUnitOfWork.SaveChanges(CancellationToken cancellationToken)
        {
            _context.SaveChanges();
        }

        public void Commit()
        {
            _dbTransaction.Commit();
            _dbTransaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            _dbTransaction.Rollback();
            _dbTransaction.Dispose();
        }

        void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_context.Database.CurrentTransaction != null) return;
            IsolationLevel actualIsolationLevel = isolationLevel != null ? isolationLevel : IsolationLevel.Serializable;
            _dbTransaction = _context.Database.BeginTransaction(actualIsolationLevel);
        }
    }
}
