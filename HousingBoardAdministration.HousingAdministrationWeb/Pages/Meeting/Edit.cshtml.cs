using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting
{
    [Authorize(Policy = "IsAdminPolicy")]
    public class EditModel : PageModel
    {
        private IBffClient _bffClient;

        public EditModel(IBffClient bffClient)
        {
            this._bffClient = bffClient;
        }

        [BindProperty]
        public MeetingEditViewModel MeetingModel { get; set; } = new();
        public async Task<IActionResult> OnGet(Guid id)
        {
            var result = await _bffClient.GetMeetingAsync(id);
            MeetingModel = new MeetingEditViewModel
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                AddressLocation = result.AddressLocation,
                MeetingTime = result.MeetingTime,
                RowVersion = result.RowVersion
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            await _bffClient.EditMeetingAsync(MeetingModel);

            return RedirectToPage("./Index");
        }

    }
}
