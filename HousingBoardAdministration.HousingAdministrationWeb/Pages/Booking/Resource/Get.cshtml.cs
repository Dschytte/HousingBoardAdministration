using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking.Resource
{
    [Authorize(Policy = "IsResidentPolicy")]

    public class GetModel : PageModel
    {
        private readonly IBookingBffClient _bookingBffClient;

        public GetModel(IBookingBffClient bookingBffClient)
        {
            _bookingBffClient = bookingBffClient;
        }

        [BindProperty]
        public GetResourceViewModel ResourceModel { get; set; } = new();

        public async Task<IActionResult> OnGet(Guid id)
        {
            ResourceModel = await _bookingBffClient.GetResourceByIdWithBookingsAsync(id);
            return Page();
        }
    }
}
