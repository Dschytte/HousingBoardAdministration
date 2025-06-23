using BookingSystemApi.Application.Commands.Resident.Create;
using BookingSystemApi.Application.Commands.Resident.Delete;
using BookingSystemApi.Application.IRepositories;
using BookingSystemApi.Application.Queris.Resident.GetAllResident;
using BookingSystemApi.Application.Queris.Resident.GetResident;
using BookingSystemApi.Domain.Entities;
using BookingSystemApi.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Infrastructure.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly BookingSystemDbContext _db;
        public ResidentRepository(BookingSystemDbContext db)
        {
            _db = db;
        }

        void IResidentRepository.Update(ResidentEntity model)
        {
            _db.Update(model);
            _db.SaveChanges();
        }

        ResidentEntity IResidentRepository.Load(Guid id)
        {
            var model = _db.ResidentEntities.FirstOrDefault(x => x.Id == id);
            return model == null ? throw new Exception("Der blev ingen Resident fundet") : model;
        }

        void IResidentRepository.Create(CreateResidentCommand request)
        {

            var model = new ResidentEntity
            {
                Id = request.UserId,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ResidentAddress = request.ResidentAddress

            };
            _db.Add(model);
            _db.SaveChanges();
        }

        void IResidentRepository.Delete(DeleteResidentCommand request)
        {
            _db.Remove(_db.ResidentEntities.AsNoTracking().FirstOrDefault(x => x.Id == request.Id));
            _db.SaveChanges();
        }


        public void GetAll()
        {
            throw new NotImplementedException();
        }

        GetResidentQueryResult IResidentRepository.Get(GetResidentQuery request)

        {
            var model = _db.ResidentEntities.Include(type => type.Booking).FirstOrDefault(x => x.Id == request.Id);


            if (model == null) throw new Exception("No Resident found");
            return new GetResidentQueryResult
            {
                Id = model.Id,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ResidentAddress = model.ResidentAddress,
                Booking = model.Booking.Select(Booking => new BookingDto
                {
                    Id = Booking.Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,

                }).ToList(),
            };
        }

        IEnumerable<GetAllResidentQueryResult> IResidentRepository.GetAll(Guid id)
        {
            var ResidentModel = _db.ResidentEntities.AsNoTracking();

            foreach (var model in ResidentModel)
            {
                yield return new GetAllResidentQueryResult
                {
                    Id = model.Id,
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ResidentAddress = model.ResidentAddress,
                };
            }
        }

    }
}
