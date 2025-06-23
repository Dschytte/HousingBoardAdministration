using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking
{
    public class CreateBookingViewModel
    {
        [Required(ErrorMessage = "Booking Owner is required.")]
        public Guid BookingOwnerId { get; set; }

        [Required(ErrorMessage = "At least one resource must be selected.")]
        public List<Guid>? ResourceIdsList { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

    }
}
