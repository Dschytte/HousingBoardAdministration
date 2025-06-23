using BookingSystemApi.Application.Commands.Booking.Create;
using BookingSystemApi.Application.Commands.Booking.Delete;
using BookingSystemApi.Application.Queris.Booking.Dto;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.IRepositories
{
    public interface IBookingRepository
    {
        BookingEntity Load(Guid id);
        bool Create(CreateBookingCommand request);
        BookingGetQueryResultDto Get(Guid id);

        void Delete(DeleteBookingCommand request);
        void Edit(BookingEntity request);
        IEnumerable<BookingGetAllQueryResultDto> GetAll(Guid userId);
    }
}


