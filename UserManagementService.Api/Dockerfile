#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UserManagementService.Api1/UserManagementService.Api1.csproj", "UserManagementService.Api1/"]
RUN dotnet restore "UserManagementService.Api1/UserManagementService.Api1.csproj"
COPY . .
WORKDIR "/src/UserManagementService.Api1"
RUN dotnet build "UserManagementService.Api1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagementService.Api1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementService.Api1.dll"]