using HousingBoardApi.Application.Queries.MeetingType.Implementation;
using HousingBoardApi.Application.Queries.MeetingType.Interface;
using HousingBoardApi.Application.Queries.Role.Implementation;
using HousingBoardApi.Application.Queries.Role.Interface;
using HousingBoardApi.Application.Transaction.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HousingBoardApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });


        services.AddScoped<IMeetingTypeGetQuery, MeetingTypeGetQuery>();
        services.AddScoped<IMeetingTypeGetAllQuery, MeetingTypeGetAllQuery>();
        services.AddScoped<IRoleGetAllQuery, RoleGetAllQuery>();
        services.AddScoped<IRoleGetQuery, RoleGetQuery>();


        return services;
    }
}
