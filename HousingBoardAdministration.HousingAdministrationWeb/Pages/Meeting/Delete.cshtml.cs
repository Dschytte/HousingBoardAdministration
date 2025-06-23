using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting
{
    [Authorize(Policy = "IsAdminPolicy")]
    public class DeleteModel : PageModel
    {
        private readonly IBffClient _bffClient;

        public DeleteModel(IBffClient bffClient)
        {
            this._bffClient = bffClient;
        }

        public static bool ContainsDocument { get; set; }

        [BindProperty]
        public MeetingDeleteViewModel MeetingModel { get; set; } = new();
        public async Task<IActionResult> OnGet(Guid id)
        {
            var dto = await _bffClient.GetMeetingAsync(id);

            if (dto.Documents.Count > 0)
            {
                ContainsDocument = true;

            }
            else
            {
                ContainsDocument = false;
            }

            MeetingModel = new MeetingDeleteViewModel
            {
                Id = dto.Id
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (!ContainsDocument)
            {
                await _bffClient.DeleteMeetingAsync(MeetingModel);
                return RedirectToPage("./index");
            }
            else
            {
                TempData["ErrorMes"] = "Mødet indeholder dokumenter, slet dokumenterne for at gennemføre sletningen!";
                return Page();
            }

        }
    }
}
