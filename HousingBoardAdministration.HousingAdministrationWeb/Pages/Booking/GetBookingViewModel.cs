using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking
{
    public class GetBookingViewModel
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ResourceViewModel> Resources { get; set; }

        public Guid BookingOwnerId { get; set; }

    }
}
