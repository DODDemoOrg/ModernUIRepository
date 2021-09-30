FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ModernUIApp/ModernUIApp.csproj", "ModernUIApp/"]
RUN dotnet restore "ModernUIApp/ModernUIApp.csproj"
COPY . .
WORKDIR "/src/ModernUIApp"
RUN dotnet build "ModernUIApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModernUIApp.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ApiURL http://modernapiapp/api/customers
ENV ASPNETCORE_ENVIRONMENT Development
ENV LaunchDarklyKey sdk-648f2d04-80a7-4892-b563-62db2dec3c5c

ENTRYPOINT ["dotnet", "ModernUIApp.dll"]