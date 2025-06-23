using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Queris.Resource.GetAllResourcesQuery
{
    public class GetAllResourcesQueryHandler : IRequestHandler<GetAllResourcesQuery, List<GetAllResourcesQueryResult>>
    {
        private readonly IResourceRepository _resourceRepository;

        public GetAllResourcesQueryHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        Task<List<GetAllResourcesQueryResult>> IRequestHandler<GetAllResourcesQuery, List<GetAllResourcesQueryResult>>.Handle(GetAllResourcesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_resourceRepository.GetAll(request).ToList());
        }
    }
}
