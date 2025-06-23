using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Commands.Resource.Create;

public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand>
{
    private readonly IResourceRepository _resourceRepository;

    public CreateResourceCommandHandler(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public Task Handle(CreateResourceCommand request, CancellationToken cancellationToken)
    {
        _resourceRepository.Create(request);
        return Task.CompletedTask;
    }
}
