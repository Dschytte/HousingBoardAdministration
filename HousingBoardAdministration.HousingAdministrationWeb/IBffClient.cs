using HousingBoardAdministration.HousingAdministrationWeb.Areas.Identity.Pages.Account.ListViewModels;
using HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard;
using HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard.BoardMember;
using HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting;
using HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting.Document;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace HousingBoardAdministration.HousingAdministrationWeb
{
    public interface IBffClient
    {

        //attribute body
        [Post("/document")]
        Task CreateDocumentAsync([Body] DocumentCreateViewModel documentCreateViewModel);
        [Get("/document/{id}")]
        Task<DocumentViewModel> GetDocumentAsync([Path] Guid id);
        [Get("/role")]
        Task<List<RoleViewModel>> GetAllRolesAsync();
        [Post("/boardmember")]
        Task CreateBoardMemberAsync([Body] CreateBoardMemberDto createBoardMemberDto);
        [Post("/boardmemberrole")]
        Task CreateBoardMemberRoleAsync([Body] CreateBoardMemberRoleDto createBoardMemberRoleDto);

        [Put("/boardmember")]
        Task EditBoardMemberAsync([Body] BoardMemberEditViewModel editBoardMemberDto);

        [Get("/meeting")]
        Task<List<MeetingIndexViewModel>> GetAllMeetingsAsync();

        [Put("/meeting")]
        Task EditMeetingAsync([Body] MeetingEditViewModel meetingEditViewModel);

        [Get("/meetingtype")]
        Task<List<MeetingTypeViewModel>> GetAllMeetingTypesAsync();

        [Get("/meeting/{id}")]
        Task<GetMeetingViewModel> GetMeetingAsync([Path] Guid id);
        [Post("/meeting")]
        Task CreateMeetingAsync([Body] MeetingCreateViewModel meetingCreateViewModel);

        [Get("/documenttype")]
        Task<List<DocumentTypeViewModel>> GetAllDocumentTypesAsync();

        [Delete("/Document")]
        Task DeleteDocumentAsync([Body] DocumentDeleteViewModel documentModel);
        [Delete("/Meeting")]
        Task DeleteMeetingAsync([Body] MeetingDeleteViewModel meetingModel);

        [Get("/boardmember")]
        Task<List<BoardMembersWithRolesViewModel>> GetAllBoardMembersWithRolesAsync();

        [Get("/boardmember/{id}")]
        Task<BoardMemberWithAllRolesViewModel> GetBoardMemberWithAllRolesAsync([Path] Guid id, [FromQuery] bool includeOldRoles);
    }
}
