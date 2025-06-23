using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Domain.Common;
public abstract class BaseEntity
{
    public BaseEntity()
    {

    }
    public Guid Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public bool IsDeleted { get; set; }

}
