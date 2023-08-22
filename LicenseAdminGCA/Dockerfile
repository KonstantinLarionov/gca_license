FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LicenseAdminGCA/LicenseAdminGCA.csproj", "LicenseAdminGCA/"]
RUN dotnet restore "LicenseAdminGCA/LicenseAdminGCA.csproj"
COPY . .
WORKDIR "/src/LicenseAdminGCA"
RUN dotnet build "LicenseAdminGCA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LicenseAdminGCA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LicenseAdminGCA.dll"]
