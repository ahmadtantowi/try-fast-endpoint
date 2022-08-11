# Publish application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
USER 0
WORKDIR /src
COPY . ./
RUN dotnet restore .
RUN dotnet publish --no-restore -c Release -o /out .

# Build application image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY --from=build-env /out /app
ENV ASPNETCORE_URLS=http://*:8080
CMD ["dotnet", "/app/TryFastEndpoint.dll"]
