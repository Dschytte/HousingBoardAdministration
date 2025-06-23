using System.Data;

namespace BookingSystemApi.Application.Transaction
{
    public interface IUnitOfWork
    {
        void SaveChanges(CancellationToken cancellationToken);
        void Commit();
        void Rollback();
        void BeginTransaction(IsolationLevel isolationLevel);
    }
}
