
using HousingBoardApi.Application.Transaction;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace HousingBoardApi.Infrastructure.TransactionHandling.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly HousingBoardDbContext _db;
    private IDbContextTransaction _dbTransaction;

    public UnitOfWork(HousingBoardDbContext db)
    {
        this._db = db;
    }
    public void BeginTransaction(IsolationLevel isolationLevel)
    {
        if (_db.Database.CurrentTransaction != null) return;
        IsolationLevel actualIsolationLevel = isolationLevel != null ? isolationLevel : IsolationLevel.Serializable;
        _dbTransaction = _db.Database.BeginTransaction(actualIsolationLevel);
    }

    public void Commit()
    {
        _dbTransaction.Commit();
        _dbTransaction.Dispose();
    }

    public void Rollback()
    {
        _dbTransaction.Rollback();
        _dbTransaction.Dispose();
    }

    void IUnitOfWork.SaveChanges(CancellationToken cancellationToken)
    {
        _db.SaveChanges();
    }
}
