using System.ComponentModel.DataAnnotations;

namespace HousingBoardApi.Application.Commands.BoardMember.Edit
{
    public class EditBoardMemberCommand : IRequest
    {
        public Guid Id { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResidentAddress { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
