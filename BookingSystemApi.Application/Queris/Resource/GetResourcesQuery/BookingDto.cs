
using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Application.Queris.Resource.GetResourcesQuery;

public class BookingDto
{
    public Guid Id { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid BookingOwnerId { get; set; }
}
