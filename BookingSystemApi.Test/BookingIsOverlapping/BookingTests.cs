using BookingSystemApi.Application.DomainService.Implementering;
using BookingSystemApi.Application.IRepositories;
using BookingSystemApi.Application.Queris.Resource.GetResourcesQuery;
using BookingSystemApi.Domain.DomainService;
using Moq;

namespace BookingSystemApi.Test.BookingIsOverlapping;

public class BookingTests
{
    private readonly Mock<IResourceRepository> _resourceRepositoryMock;
    private readonly IBookingDateValidationService _bookingDateValidationService;

    public BookingTests()
    {
        _resourceRepositoryMock = new Mock<IResourceRepository>();
        _bookingDateValidationService = new BookingDateValidationService(_resourceRepositoryMock.Object);
    }

    [Theory]
    // Test af dato før eksisterende booking
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/03 05:00", "2023/06/05 06:00")]
    // Test af dato efter eksisterende booking
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2024/11/01", "2024/12/01")]
    // Test af dato før eksisterende booking til før grænseværdi startdato for booking
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/03 05:00", "2023/06/05 09:59")]
    // Test af dato før eksisterende booking til efter grænseværdi slutdato for booking
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/10 10:01", "2023/06/12 10:00")]

    public void Given_that_bookings_dont_Overlap_Create_new_Booking_NoOverlap(string guid, string startdate, string enddate)
    {
        // Arrange
        var resourceid = Guid.Parse(guid);

        var mockdata = new GetResourcesQueryResult
        {
            Id = resourceid,
            Description = "Desc",
            Specification = "Spec",
            RowVersion = new byte[1],
            Price = 200,
            Bookings = new BookingDto[]
            {
                new BookingDto
                {
                    Id = Guid.NewGuid(),
                    BookingOwnerId = Guid.NewGuid(),
                    RowVersion = new byte[1],
                    StartDate = DateTime.Parse("2023/06/05 10:00"),
                    EndDate = DateTime.Parse("2023/06/10 10:00")
                }
            }.ToList()
        };

        _resourceRepositoryMock.Setup(repo => repo.Get(It.IsAny<GetResourcesQuery>())).Returns(mockdata);

        // Act
        var result = _bookingDateValidationService.IsResourceAvailableAsync(resourceid, DateTime.Parse(startdate), DateTime.Parse(enddate));

        // Assert
        Assert.True(result);
    }

    [Theory]
    // test på overlapning af dato inden i eksisterende booking dato
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/06 10:00", "2023/06/09 10:00")]
    // test på overlapning af dato fra venstre
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/03 10:00", "2023/06/06 10:00")]
    // test på overlapning af dato fra højre
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/08 10:00", "2023/06/12 10:00")]
    // test på dato der overlapper dato både med start og slut dato
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2022/06/01 10:00", "2024/06/12 10:00")]
    // test på samme dato
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2022/06/05 10:00", "2024/06/10 10:00")]
    // Test af dato før eksisterende booking til grænseværdi startdato for booking
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/03 05:00", "2023/06/05 10:00")]
    // Test af dato før eksisterende booking til grænseværdi slutdato for booking
    [InlineData("5bf48e61-5ea6-4040-9816-046c2eed2b25", "2023/06/10 10:00", "2023/06/12 10:00")]
    public void Given_that_bookings_Overlap_Create_new_Booking_Overlap(string guid, string startdate, string enddate)
    {
        // Arrange
        var resourceid = Guid.Parse(guid);

        var mockdata = new GetResourcesQueryResult
        {
            Id = resourceid,
            Description = "Desc",
            Specification = "Spec",
            RowVersion = new byte[1],
            Price = 200,
            Bookings = new BookingDto[]
            {
                new BookingDto
                {
                    Id = Guid.NewGuid(),
                    BookingOwnerId = Guid.NewGuid(),
                    RowVersion = new byte[1],
                    StartDate = DateTime.Parse("2023/06/05 10:00"),
                    EndDate = DateTime.Parse("2023/06/10 10:00")
                }
            }.ToList()
        };

        _resourceRepositoryMock.Setup(repo => repo.Get(It.IsAny<GetResourcesQuery>())).Returns(mockdata);

        // Act
        var result = _bookingDateValidationService.IsResourceAvailableAsync(resourceid, DateTime.Parse(startdate), DateTime.Parse(enddate));

        // Assert
        Assert.False(result);
    }
}

