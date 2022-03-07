# CMC
# ASP.NET 6 / React

This app is a template application using ASP.NET 6 for a REST/JSON API server and React for a web client.

## Overview of Stack
- Server
  - ASP.NET 6
  - Entity Framework Core In memory
- Client
  - React 17
  - CSS Modules
  - Fetch API for REST requests
- Testing
  - xUnit for .NET
  - Enzyme for React


## Setup

1. Install the following:
   - [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
   - [Node.js ](https://nodejs.org/en/download/)
2. run .Net project in Visual Studio 2022
3. Run React project in VScode by using these commands `npm install && npm start`
   - [FrontEnd - React Project](https://github.com/plus24/CMC/tree/main/CMC.UI/cmc-app)
4. Open browser and navigate to [http://localhost:3000](http://localhost:3000).



## Scripts

### `npm install`

When first cloning the repo or adding new dependencies, run this command.  This will:

- Install Node dependencies from package.json
- Install .NET dependencies from CMC/CMC.csproj (using dotnet restore)

### `npm start`


### `npm test`

This will run the test cases.
