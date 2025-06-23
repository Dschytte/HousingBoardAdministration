using System.Transactions;

namespace BookingSystemApi.Application.Transaction.Behaviors
{
    public sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (IsNotCommand())
            {
                return next();
            }

            using (var transactionScope = new TransactionScope())
            {
                var response = next();
                _unitOfWork.SaveChanges(cancellationToken);

                transactionScope.Complete();
                return response;

            }
        }

        private bool IsNotCommand()
        {
            return !typeof(TRequest).Name.EndsWith("Command");
        }
    }
}
