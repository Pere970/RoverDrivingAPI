FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
COPY ["/src/*/*.csproj", "/app/roverdrivingapi/"]
WORKDIR /app/roverdrivingapi
RUN dotnet restore -r linux-x64

COPY /src/* ./
RUN dotnet publish -c release -o out -r linux-x64 --self-contained true --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
ENV ASPNETCORE_URLS http://+:5000
WORKDIR /app
COPY --from=build /app/roverdrivingapi/out .
ENTRYPOINT ["./Rover.Driving.Api"]
