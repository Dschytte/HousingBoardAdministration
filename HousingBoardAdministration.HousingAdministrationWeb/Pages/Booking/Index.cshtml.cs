using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking
{
    [Authorize(Policy = "IsResidentPolicy")]
    public class IndexModel : PageModel
    {
        private readonly IBookingBffClient _bookingBffClient;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(IBookingBffClient bookingBffClient, UserManager<IdentityUser> userManager)
        {
            _bookingBffClient = bookingBffClient;
            _userManager = userManager;
        }

        [BindProperty]
        public List<BookingViewModel> BookingViewModels { get; set; } = new();

        [BindProperty]
        public List<BookingViewModel> OldBookingViewModels { get; set; } = new();

        public async Task OnGet()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var dateutc = DateTime.Now;

            var result = await _bookingBffClient.GetBookingsByuserId(userId);

            BookingViewModels = result.Where(x => (x.StartDate <= dateutc && x.EndDate >= dateutc) || (x.StartDate >= dateutc && x.EndDate >= dateutc)).ToList();
            OldBookingViewModels = result.Where(x => x.StartDate < dateutc && x.EndDate < dateutc).ToList();
        }
    }
}
