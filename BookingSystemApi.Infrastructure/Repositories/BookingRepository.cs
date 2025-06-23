using BookingSystemApi.Application.Commands.Booking.Create;
using BookingSystemApi.Application.Commands.Booking.Delete;
using BookingSystemApi.Application.IRepositories;
using BookingSystemApi.Application.Queris.Booking.Dto;
using BookingSystemApi.Domain.Entities;
using BookingSystemApi.SqlServerContext;
using Microsoft.EntityFrameworkCore;


namespace BookingSystemApi.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly BookingSystemDbContext _db;

    public BookingRepository(BookingSystemDbContext db)
    {
        _db = db;
    }

    void IBookingRepository.Delete(DeleteBookingCommand request)
    {
        _db.Remove(_db.BookingEntities.AsNoTracking().FirstOrDefault(x => x.Id == request.Id));
        _db.SaveChanges();
    }

    void IBookingRepository.Edit(BookingEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();

    }

    public BookingGetQueryResultDto Get(Guid id)
    {
        var model = _db.BookingEntities.Include(type => type.Resources).Include(x => x.BookingOwner).FirstOrDefault(x => x.Id == id);


        if (model == null) throw new Exception("Ingen booking fundet i databasen");

        return new BookingGetQueryResultDto
        {
            Id = model.Id,
            RowVersion = model.RowVersion,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            BookingOwnerId = model.BookingOwner.Id,
            Resources = model.Resources.Select(resource => new ResourceDto
            {
                Id = resource.Id,
                Description = resource.Description,
                Specification = resource.Specification,
                Price = resource.Price,
            }).ToList(),
        };
    }

    BookingEntity IBookingRepository.Load(Guid id)
    {
        var model = _db.BookingEntities.FirstOrDefault(x => x.Id == id);
        return model == null ? throw new Exception("Ingen Booking fundet i databasen") : model;
    }

    bool IBookingRepository.Create(CreateBookingCommand request)
    {
        try
        {

            ResidentEntity resident = new ResidentEntity { Id = request.BookingOwnerId };
            List<ResourceEntity> resourceList = request.ResourceIdsList.Select(id => new ResourceEntity { Id = id }).ToList();

            _db.Attach(resident);
            foreach (ResourceEntity resource in resourceList)
            {
                _db.Attach(resource);
            }
            BookingEntity model = new BookingEntity
            {


                StartDate = request.StartDate,
                EndDate = request.EndDate,
                BookingOwner = resident,
                Resources = resourceList

            };

            _db.Add(model);
            _db.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    IEnumerable<BookingGetAllQueryResultDto> IBookingRepository.GetAll(Guid userId)
    {
        foreach (var model in _db.BookingEntities.AsNoTracking().Include(x => x.BookingOwner).Where(booking => booking.BookingOwner.Id == userId).ToList())
        {
            yield return new BookingGetAllQueryResultDto
            {
                Id = model.Id,
                RowVersion = model.RowVersion,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                BookingOwnerId = model.BookingOwner.Id
            };
        }
    }
}
