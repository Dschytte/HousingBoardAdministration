using BookingSystemApi.Application.Commands.Resource.Create;
using BookingSystemApi.Application.Commands.Resource.Delete;
using BookingSystemApi.Application.Queris.Resource.GetAllResourcesQuery;
using BookingSystemApi.Application.Queris.Resource.GetResourcesQuery;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.IRepositories;

public interface IResourceRepository
{
    void Create(CreateResourceCommand request);

    void Delete(DeleteResourceCommad request);
    GetResourcesQueryResult Get(GetResourcesQuery request);
    IEnumerable<GetAllResourcesQueryResult> GetAll(GetAllResourcesQuery request);

    ResourceEntity Load(Guid id);

    void Update(ResourceEntity request);
}

