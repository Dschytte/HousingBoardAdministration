using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting.Document
{
    [Authorize(Policy = "IsAdminOrBoardMemberPolicy")]
    public class DeleteModel : PageModel
    {
        private readonly IBffClient _bffClient;
        private readonly UserManager<IdentityUser> _userManager;


        public DeleteModel(IBffClient bffClient, UserManager<IdentityUser> userManager)
        {
            this._bffClient = bffClient;
            _userManager = userManager;
        }
        public static Guid MeetingId { get; set; }

        [BindProperty]
        public DocumentDeleteViewModel DocumentModel { get; set; } = new();

        public static Guid DocumentOwnerId { get; set; } = new();
        public async Task<IActionResult> OnGet(Guid meetingId, Guid documentId)
        {
            MeetingId = meetingId;
            var dto = await _bffClient.GetDocumentAsync(documentId);

            DocumentModel = new DocumentDeleteViewModel
            {
                Id = dto.Id
            };

            DocumentOwnerId = dto.UserOwnerId;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (DocumentOwnerId == Guid.Parse(_userManager.GetUserId(User)))
            {
                await _bffClient.DeleteDocumentAsync(DocumentModel);
            }
            else
            {
                TempData["ErrorMes"] = "Du kan kun slette dine egne dokumenter!";
                return Page();
            }

            return RedirectToPage("/Meeting/Get", new { id = MeetingId });
        }
    }
}
