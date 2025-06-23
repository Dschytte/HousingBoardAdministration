using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard
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
        public List<BoardMembersWithRolesViewModel> BoardMembersViewModel { get; set; }
        public async Task<ActionResult> OnGet()
        {
            BoardMembersViewModel = await _bffClient.GetAllBoardMembersWithRolesAsync();
            return Page();
        }
    }
}
