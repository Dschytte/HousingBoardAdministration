using HousingBoardAdministration.HousingAdministrationWeb.Areas.Identity.Pages.Account.ListViewModels;
using HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking;
using HousingBoardAdministration.HousingAdministrationWeb.Pages.Booking.Resource;
using RestEase;

namespace HousingBoardAdministration.HousingAdministrationWeb;

public interface IBookingBffClient
{
    //attribute body
    [Post("/resident")]
    Task CreateResidentAsync([Body] CreateResidentDto createResidentDto);
    [Get("/Booking/GetBookingsByUserId/{userId}")]
    Task<List<BookingViewModel>> GetBookingsByuserId([Path] Guid userId);
    [Get("/Booking/{id}")]
    Task<GetBookingViewModel> GetBookingById([Path] Guid id);
    [Post("/Booking")]
    Task<bool> CreateBookingAsync([Body] CreateBookingViewModel createBookingViewModel);
    [Get("/ressource")]
    Task<List<ResourceViewModel>> GetAllResourcesAsync();
    [Get("/ressource/{id}")]
    Task<GetResourceViewModel> GetResourceByIdWithBookingsAsync([Path] Guid id);
}
