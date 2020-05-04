#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY DVDRentalAPI/DVDRentalAPI.csproj DVDRentalAPI/
COPY DVDRentalAPI.Core/DVDRentalAPI.Core.csproj DVDRentalAPI.Core/
COPY DVDRentalAPI.Repository/DVDRentalAPI.Repository.csproj DVDRentalAPI.Repository/
COPY DVDRentalAPI.Helpers/DVDRentalAPI.Helpers.csproj DVDRentalAPI.Helpers/
COPY DVDRentalAPI.Services/DVDRentalAPI.Services.csproj DVDRentalAPI.Services/
COPY DVDRentalAPI.Models/DVDRentalAPI.Models.csproj DVDRentalAPI.Models/
RUN dotnet restore "DVDRentalAPI/DVDRentalAPI.csproj"
COPY . .
WORKDIR "/src/DVDRentalAPI"
RUN dotnet build "DVDRentalAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DVDRentalAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DVDRentalAPI.dll"]
