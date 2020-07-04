using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShakespearesPokemon.Models;

namespace ShakespearesPokemon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
       

        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        //GET: api/Pokemon
        [HttpGet]
        public ActionResult<Pokemon> Get()
        {
            return new Pokemon
            {
                Name = "Charizard",
                Description = "I am Charizard"
            };
        }
    }
}
