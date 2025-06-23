using BookingSystemApi.Application.Commands.Resident.Create;
using BookingSystemApi.Application.Commands.Resident.Delete;
using BookingSystemApi.Application.Queris.Resident.GetAllResident;
using BookingSystemApi.Application.Queris.Resident.GetResident;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.IRepositories
{
    public interface IResidentRepository
    {
        void Create(CreateResidentCommand request);
        void Update(ResidentEntity request);
        ResidentEntity Load(Guid id);
        void Delete(DeleteResidentCommand request);
        GetResidentQueryResult Get(GetResidentQuery request);
        IEnumerable<GetAllResidentQueryResult> GetAll(Guid id);

    }
}
