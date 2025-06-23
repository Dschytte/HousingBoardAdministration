using System.ComponentModel.DataAnnotations;

namespace HousingBoardApi.Domain.Common;
public abstract class BaseEntity : ISoftDelete
{
    public Guid Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}
