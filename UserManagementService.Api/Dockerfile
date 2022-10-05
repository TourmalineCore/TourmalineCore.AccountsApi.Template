#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserManagementService.ApiNew/UserManagementService.ApiNew.csproj", "UserManagementService.ApiNew/"]
RUN dotnet restore "UserManagementService.ApiNew/UserManagementService.ApiNew.csproj"
COPY . .
WORKDIR "/src/UserManagementService.ApiNew"
RUN dotnet build "UserManagementService.ApiNew.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagementService.ApiNew.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementService.ApiNew.dll"]