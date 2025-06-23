using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking
{
    [Authorize(Policy = "IsResidentPolicy")]

    public class CreateModel : PageModel
    {
        private IBookingBffClient _bookingBffClient;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(IBookingBffClient bookingBffClient, UserManager<IdentityUser> userManager)
        {
            _bookingBffClient = bookingBffClient;
            _userManager = userManager;
        }

        [BindProperty]
        public CreateBookingViewModel BookingModel { get; set; } = new();
        public List<ResourceViewModel> AllResources { get; set; } = new();

        public async Task OnGetAsync()
        {
            AllResources = await _bookingBffClient.GetAllResourcesAsync();

            BookingModel.StartDate = DateTime.Now.Date;
            BookingModel.EndDate = DateTime.Now.Date;
        }

        public bool CheckIfDateIsValid()
        {
            if (BookingModel.StartDate < DateTime.Now)
            {
                TempData["ErrorMes"] = "Start datoen er ugyldig!";
                return false;

            }
            if (BookingModel.EndDate < DateTime.Now)
            {
                TempData["ErrorMes"] = "Slut datoen er gyldig!";
                return false;

            }
            return true;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            BookingModel.BookingOwnerId = Guid.Parse(_userManager.GetUserId(User));


            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (!CheckIfDateIsValid())
                {
                    return Page();
                }
                // Opret booking ved hjælp af _bffClient
                var result = await _bookingBffClient.CreateBookingAsync(BookingModel);

                if (result == false)
                {
                    TempData["ErrorMes"] = "En af resourserne er booket i den periode!";
                }
                else
                {
                    return RedirectToPage("./index");

                }

                // Redirect til en bekræftelsesside eller en oversigtsside TODO
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Der skete en fejl ved oprettelse: " + ex.Message);
                return Page();
            }
            return Page();
        }
    }
}
