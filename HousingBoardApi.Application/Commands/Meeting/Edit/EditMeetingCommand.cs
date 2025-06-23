
using System.ComponentModel.DataAnnotations;

namespace HousingBoardApi.Application.Commands.Meeting.Edit;

public record EditMeetingCommand : IRequest
{
    public Guid Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime MeetingTime { get; set; }
    public string AddressLocation { get; set; }
}
