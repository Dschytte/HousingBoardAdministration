using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking.Resource;

public class BookingDto
{
    public Guid Id { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid BookingOwnerId { get; set; }
}
