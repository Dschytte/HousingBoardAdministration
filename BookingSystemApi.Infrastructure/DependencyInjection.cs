using BookingSystemApi.Application.IRepositories;
using BookingSystemApi.Application.Transaction;
using BookingSystemApi.Infrastructure.Repositories;
using BookingSystemApi.Infrastructure.TransactionHandling.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystemApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IResourceRepository, ResourceRepository>();
        services.AddScoped<IResidentRepository, ResidentRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
