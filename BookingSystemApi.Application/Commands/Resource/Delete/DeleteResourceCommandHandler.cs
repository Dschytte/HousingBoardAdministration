using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Commands.Resource.Delete
{
    public class DeleteResourceCommandHandler : IRequestHandler<DeleteResourceCommad>
    {
        private readonly IResourceRepository _resourceRepository;

        public DeleteResourceCommandHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        Task IRequestHandler<DeleteResourceCommad>.Handle(DeleteResourceCommad request, CancellationToken cancellationToken)
        {
            _resourceRepository.Delete(request);
            return Task.CompletedTask;
        }
    }
}
