using System.Data;

namespace HousingBoardApi.Application.Transaction;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel);
    void SaveChanges(CancellationToken cancellationToken);
}
