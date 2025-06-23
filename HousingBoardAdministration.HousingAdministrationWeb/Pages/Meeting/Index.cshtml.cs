using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting
{
    [Authorize(Policy = "IsAdminOrBoardMemberPolicy")]
    public class IndexModel : PageModel
    {
        private readonly IBffClient _bffClient;

        public IndexModel(IBffClient bffClient)
        {

            this._bffClient = bffClient;
        }


        [BindProperty]
        public List<MeetingIndexViewModel> MeetingsViewModel { get; set; }

        [BindProperty]
        public List<MeetingIndexViewModel> OldMeetingsViewModel { get; set; }
        public async Task<ActionResult> OnGet()
        {
            var meetings = await _bffClient.GetAllMeetingsAsync();
            MeetingsViewModel = meetings.Where(x => x.MeetingTime >= DateTime.Now).ToList();
            OldMeetingsViewModel = meetings.Where(x => x.MeetingTime < DateTime.Now).ToList();

            return Page();
        }
    }
}
