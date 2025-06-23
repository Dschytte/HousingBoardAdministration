namespace HousingBoardApi.Domain.Entities;

public class BoardMemberEntity : BaseEntity
{
    public BoardMemberEntity() { }
    public BoardMemberEntity(string username, string firstname, string lastname, string residentaddress)
    {
        UserName = username;
        FirstName = firstname;
        LastName = lastname;
        ResidentAddress = residentaddress;
    }


    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ResidentAddress { get; set; }
    public List<BoardMemberRoleEntity> Roles { get; set; }
    //public string FullName { get { return FullName; } set { FullName = FirstName + " " + LastName; } }
    public ICollection<DocumentEntity>? Documents { get; set; }
    public ICollection<MeetingEntity>? Meetings { get; set; }

    public void Edit(string firstName, string lastName, string residentaddress, byte[] RowVersion)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        //this.UserName = userName;
        this.ResidentAddress = residentaddress;
        this.RowVersion = RowVersion;
    }
}
