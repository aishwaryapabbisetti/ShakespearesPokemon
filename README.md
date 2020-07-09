# ShakespearesPokemon
This is a repository to retrieve the Shakespear's description for various Pokemon characters.

### Project Structure:

* `ShakespearesPokemon.sln`  Visual Studio 2019 solution containing all the related projects,
* `ShakespearesPokemon` C# .NET Core Web API for the RESTful service that helps to familiarize with various Pokemon characters in Shakespeare's language.
* `ShakespearesPokemon.Tests` C# .NET Core xUnit Tests, contains all tests that test the functionality of ShakespearesPokemon Web API.
	
### Installation & Requirements:

* [Download](https://dotnet.microsoft.com/download/dotnet-core/3.1) .NET Core 3.1.3 SDK with IIS support.
* [Swashbuckle.AspNetCore 5.5.1](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) This is a user friendly GUI for running Web APIs.
	- To install, In .NET CLI, Run: `dotnet add package Swashbuckle.AspNetCore --version 5.5.1`.
	
	
### Running the Project:

1. To run the ShakespearesPokemon Web API, 
	- Go to the Project folder `ShakespearesPokemon/ShakespearesPokemon` where `Startup.cs` is present. 
	- Run: `dotnet run`. This will start the server at `http://localhost:5000`.
	
2. To run the xUnit tests created for WebAPI,
	- In .NET Core CLI, Go to the Project folder where `ShakespearesPokemon.sln` is present. 
	- Run: `dotnet test`. This will run the xunit tests of WebAPI and show the results.
	
	
### API Overview & Usage:

* Once the server is up and running, you can try the API with following end point in your web browser: `http://localhost:5000/pokemon/<favorite-pokemon-character>` 
* This will return the Pokemon name with it's description in Shakespeare's language.
* For example, `http://localhost:5000/pokemon/pikachu` endpoint will return something like below:
	```
	{
	  "name": "pikachu",
	  "description": "This pokémon hath electricity-storing pouches on its cheeks. 
	  These appeareth to becometh electrically did charge during the night while pikachu sleeps.
	  't occasionally discharges electricity at which hour 't is dozy after waking up."
	}
	```
	
### Swagger GUI:

* To use Swagger GUI, Once the server is up and running, Go to: `http://localhost:5000/swagger/index.html`.
	
