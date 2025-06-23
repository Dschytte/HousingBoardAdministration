using BookingSystemApi.Application.Commands.Resource.Create;
using BookingSystemApi.Application.Commands.Resource.Delete;
using BookingSystemApi.Application.IRepositories;
using BookingSystemApi.Application.Queris.Resource.GetAllResourcesQuery;
using BookingSystemApi.Application.Queris.Resource.GetResourcesQuery;
using BookingSystemApi.Domain.Entities;
using BookingSystemApi.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Infrastructure.Repositories;

public class ResourceRepository : IResourceRepository
{
    private readonly BookingSystemDbContext _context;

    public ResourceRepository(BookingSystemDbContext context)
    {
        this._context = context;
    }

    ResourceEntity IResourceRepository.Load(Guid id)
    {
        var model = _context.ResourceEntities.FirstOrDefault(x => x.Id == id);
        return model == null ? throw new Exception("Der blev ingen resource fundet") : model;
    }
    void IResourceRepository.Update(ResourceEntity request)
    {
        _context.Update(request);
        _context.SaveChanges();
    }
    void IResourceRepository.Create(CreateResourceCommand request)
    {
        var model = new ResourceEntity
        {
            Description = request.Description,
            Specification = request.Specification,
            Price = request.Price

        };
        _context.ResourceEntities.Add(model);
        _context.SaveChanges();
    }
    void IResourceRepository.Delete(DeleteResourceCommad request)
    {
        _context.Remove(_context.ResourceEntities.AsNoTracking().FirstOrDefault(x => x.Id == request.Id));
        _context.SaveChanges();
    }

    GetResourcesQueryResult IResourceRepository.Get(GetResourcesQuery request)
    {
        var model = _context.ResourceEntities.AsNoTracking().Include(booking => booking.Bookings).ThenInclude(user => user.BookingOwner).FirstOrDefault(x => x.Id == request.Id);
        if (model == null) throw new Exception("Ingen resourcer fundet");
        return new GetResourcesQueryResult
        {
            Id = model.Id,
            Description = model.Description,
            Specification = model.Specification,
            Price = model.Price,
            RowVersion = model.RowVersion,
            Bookings = model.Bookings.Select(x => new BookingDto
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                BookingOwnerId = x.BookingOwner.Id,
                RowVersion = x.RowVersion

            }).ToList()
        };
    }

    IEnumerable<GetAllResourcesQueryResult> IResourceRepository.GetAll(GetAllResourcesQuery request)
    {
        var resourceModels = _context.ResourceEntities.AsNoTracking();
        foreach (var model in resourceModels)
        {
            yield return new GetAllResourcesQueryResult
            {
                Id = model.Id,
                Description = model.Description,
                Specification = model.Specification,
                Price = model.Price

            };
        }
    }
}
