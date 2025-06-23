using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking
{
    [Authorize(Policy = "IsResidentPolicy")]
    public class GetModel : PageModel
    {
        private IBookingBffClient _bookingBffClient;

        public GetModel(IBookingBffClient bookingBffClient)
        {
            _bookingBffClient = bookingBffClient;
        }

        [BindProperty]
        public GetBookingViewModel BookingModel { get; set; } = new();

        public async Task<IActionResult> OnGet(Guid id)
        {
            BookingModel = await _bookingBffClient.GetBookingById(id);
            return Page();

        }
    }
}
