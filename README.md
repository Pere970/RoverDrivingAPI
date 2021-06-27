# Rover Driving REST API

This is an API that simulates the interaction with a NASA Rover. It is a simple API that will allow you to interact with the vehicle and see how its position gets updated.

## Getting Started

These instructions will get you a copy of the project up and running 
on your local machine for development and testing purposes. 
### Prerequisites

In order to use and develop the openIMIS Web Application on your 
local machine, you first need to install:

* [NET Core SDK](https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial) or Visual Studio with .NET Core SDK

### Installing

To make a copy of this project on your local machine, please clone the repository.

```
git clone https://github.com/Pere970/RoverDrivingAPI.git
```

Restore the NuGet packages needed by the application using VS or [nuget CLI](https://www.nuget.org/downloads).

```
nuget restore
```

Compile the application with VS or with dotnet cli tool

```
dotnet build
```

Run the application from VS or using dotnet cli tool

```
dotnet run --project .\src\Rover.Driving.Api\Rover.Driving.Api.csproj
```
