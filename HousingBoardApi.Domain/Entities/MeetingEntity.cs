namespace HousingBoardApi.Domain.Entities;

public class MeetingEntity : BaseEntity
{
    public MeetingEntity()
    {

    }

    public MeetingEntity(string title, string description, DateTime meetingTime, string addressLocation)
    {
        this.Title = title;
        this.Description = description;
        this.MeetingTime = meetingTime;
        this.AddressLocation = addressLocation;
    }

    public MeetingEntity(string title, string description, DateTime meetingTime, string addressLocation, MeetingTypeEntity meetingtype, BoardMemberEntity boardmember)
    {
        this.Title = title;
        this.Description = description;
        this.MeetingTime = meetingTime;
        this.AddressLocation = addressLocation;
        this.MeetingType = meetingtype;
        this.MeetingOwner = boardmember;
    }


    public string Title { get; set; }
    public string Description { get; set; }
    public MeetingTypeEntity MeetingType { get; set; }
    public DateTime MeetingTime { get; set; }
    public ICollection<DocumentEntity>? Documents { get; set; }
    public BoardMemberEntity MeetingOwner { get; set; }
    public string AddressLocation { get; set; }
    public DateTime CreatedMeetingDate { get; set; }

    public void Edit(string title, string desc, DateTime meetingtime, string addresslocation, byte[] rowversion)
    {
        this.Title = title;
        this.Description = desc;
        this.MeetingTime = meetingtime;
        this.AddressLocation = addresslocation;
        this.RowVersion = rowversion;
    }





}
