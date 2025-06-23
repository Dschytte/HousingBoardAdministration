using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Application.Queris.Booking.Dto
{
    public class BookingGetAllQueryResultDto
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid BookingOwnerId { get; set; }
    }
}
