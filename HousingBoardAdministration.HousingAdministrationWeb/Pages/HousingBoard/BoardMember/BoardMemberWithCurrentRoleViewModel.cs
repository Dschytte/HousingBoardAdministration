using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard.BoardMember
{
    public class BoardMemberWithCurrentRoleViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ResidentAddress { get; set; }
        public Guid BoardMemberRoleId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
