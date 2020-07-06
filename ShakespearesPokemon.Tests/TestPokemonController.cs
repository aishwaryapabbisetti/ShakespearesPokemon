using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ShakespearesPokemon.Models;
using ShakespearesPokemon.Controllers;

namespace ShakespearesPokemon.Tests
{
    public class TestPokemonController
    {
        [Fact]
        public void TestGetPokemon_ShouldReturnDescription()
        {
            // Arrange
            var controller = new PokemonController(null);
            Pokemon pokemon = new Pokemon() {
            Name="pikachu",
            Description= "This pokémon hath electricity-storing pouches on its cheeks. These appeareth to becometh electrically did charge during the night while pikachu sleeps. 't occasionally discharges electricity at which hour 't is dozy after waking up."
            };

            // Act
            var response = controller.GetPokemon("pikachu");
            var value = (response.Result as OkObjectResult).Value as Pokemon;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(200, (response.Result as OkObjectResult).StatusCode);
            Assert.Equal(pokemon.Name, value.Name);
            Assert.Equal(pokemon.Description, value.Description);
        }
        
        [Fact]
        public void TestGetPokemon_ShouldReturnNotFound()
        {
            // Arrange
            var controller = new PokemonController(null);

            // Act
            var response = controller.GetPokemon("pikachuuuu");

            // Assert
            Assert.Equal(400, (response.Result as BadRequestObjectResult).StatusCode);
            Assert.Equal("The remote server returned an error: (404) Not Found.", (response.Result as BadRequestObjectResult).Value);
        }

        [Fact]
        public void TestGetPokemon_ShouldReturnTooManyRequests()
        {
            // Arrange
            var controller = new PokemonController(null);

            // Act
             controller.GetPokemon("ditto");
             controller.GetPokemon("ditto");
             controller.GetPokemon("ditto");
             controller.GetPokemon("ditto");
             controller.GetPokemon("ditto");
            var response = controller.GetPokemon("ditto");

            // Assert
            Assert.Equal(400, (response.Result as BadRequestObjectResult).StatusCode);
            Assert.Equal("The remote server returned an error: (429) Too Many Requests.", (response.Result as BadRequestObjectResult).Value);
        }
    }
}
