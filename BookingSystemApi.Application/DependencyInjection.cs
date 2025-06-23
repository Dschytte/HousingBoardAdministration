using BookingSystemApi.Application.DomainService.Implementering;
using BookingSystemApi.Application.Queris.Booking.Implementation;
using BookingSystemApi.Application.Queris.Booking.Interface;
using BookingSystemApi.Application.Transaction.Behaviors;
using BookingSystemApi.Domain.DomainService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookingSystemApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        services.AddScoped<IBookingGetAllQuery, BookingGetAllQuery>();
        services.AddScoped<IBookingGetQuery, BookingGetQuery>();

        services.AddScoped<IBookingDateValidationService, BookingDateValidationService>();

        return services;
    }
}
