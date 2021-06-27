# Rover Driving REST API

This is an API that simulates the interaction with a NASA Rover. It is a simple API that will allow you to interact with the vehicle and see how its position gets updated.

## Getting Started

These instructions will get you a copy of the project up and running 
on your local machine for development and testing purposes. 
### Prerequisites

In order to use and develop the openIMIS Web Application on your 
local machine, you first need to install:

* [NET Core SDK](https://dotnet.microsoft.com/download) or Visual Studio with .NET Core SDK

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

### Usage

Run the application from VS or using dotnet cli tool

```
dotnet run --project .\src\Rover.Driving.Api\Rover.Driving.Api.csproj
```

When the App is live, there are two main methods you can use. The API simulates the Rover being in a 100x100 grid planet and starting at [0,0,N] position on it.

The first method is ProcessSingleCommand, which will allow you to move the Rover one square per call. The method receives a POST with a character on the body. The given character must be F (Forward), B (Backward), L (Left), R (Right), otherwise the API will throw an error.

```
https://localhost:5001/api/Driving/ProcessSingleCommand
```

The second one is ProcessMultipleCommand, which, will allow the user to move the Rover several times in one iteration. It receives an string in the body and the string will consist in a concatenation of the previous mentioned characters ("FFLFF" for example).

```
https://localhost:5001/api/Driving/ProcessMultipleCommand
```

That's all, just turn on the API and play with the Rover on the grid!