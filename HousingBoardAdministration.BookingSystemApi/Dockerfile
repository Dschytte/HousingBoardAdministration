#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HousingBoardAdministration.BookingSystemApi/HousingBoardAdministration.BookingSystemApi.csproj", "HousingBoardAdministration.BookingSystemApi/"]
COPY ["BookingSystemApi.Infrastructure/BookingSystemApi.Infrastructure.csproj", "BookingSystemApi.Infrastructure/"]
COPY ["BookingSystemApi.Application/BookingSystemApi.Application.csproj", "BookingSystemApi.Application/"]
COPY ["BookingSystemApi.Domain/BookingSystemApi.Domain.csproj", "BookingSystemApi.Domain/"]
COPY ["BookingSystemApi.SqlServerContext/BookingSystemApi.SqlServerContext.csproj", "BookingSystemApi.SqlServerContext/"]
COPY ["BookingSystemApi.SqlServerContextMigrations/BookingSystemApi.SqlServerContextMigrations.csproj", "BookingSystemApi.SqlServerContextMigrations/"]
RUN dotnet restore "HousingBoardAdministration.BookingSystemApi/HousingBoardAdministration.BookingSystemApi.csproj"
COPY . .
WORKDIR "/src/HousingBoardAdministration.BookingSystemApi"
RUN dotnet build "HousingBoardAdministration.BookingSystemApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HousingBoardAdministration.BookingSystemApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HousingBoardAdministration.BookingSystemApi.dll"]