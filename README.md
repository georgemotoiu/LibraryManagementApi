# LibraryManagementApi

## Description

We want to create a management platform for a library.
The platform allows all kind of library managemenet (creating students, borrowing books, books management).

## Prerequisites

- .NET Core 6 for the back-end environment https://dotnet.microsoft.com/download/dotnet/6.0
-  Optional Postman 
Import postman_collection.json into Postman and run the web api app to make requests. Be sure to reimport the collection often to get the latests changes.

If you're running this project with Visual Studio, make sure you have at least the 2022 version.

If you don't want to run this with Visual Studio 2022, you can try [Visual Studio Code](https://code.visualstudio.com/) and run/debug the project with the default .NET Core Launcher. Chosing the ".Net Core & Chrome" configuration to "Run and Debug" will open swagger in the browser to test out the requests. You can try running the below commands manually and attach the debugger later:
### Restoring NuGet packages

### `dotnet restore`

### Building the project

### `dotnet build`

### Running the project

### `dotnet run --project ./LibraryManagementApi/src/LibraryManagementApi.API.csproj`