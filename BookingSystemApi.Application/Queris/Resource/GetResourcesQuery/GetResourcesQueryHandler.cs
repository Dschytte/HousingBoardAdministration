using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Queris.Resource.GetResourcesQuery
{
    public class GetResourcesQueryHandler : IRequestHandler<GetResourcesQuery, GetResourcesQueryResult>
    {
        private readonly IResourceRepository _resourceRepository;

        public GetResourcesQueryHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        Task<GetResourcesQueryResult> IRequestHandler<GetResourcesQuery, GetResourcesQueryResult>.Handle(GetResourcesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_resourceRepository.Get(request));
        }
    }
}
