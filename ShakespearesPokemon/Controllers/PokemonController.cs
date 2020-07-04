using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        //GET: /Pokemon
        [HttpGet]
        public ActionResult<Pokemon> Get()
        {
            
            return new Pokemon
            {
                Name = "Charizard",
                Description = "I am Charizard"
            };
        }

        //GET: /Pokemon/charizard
        [HttpGet("{name}")]
        public ActionResult<Pokemon> Get(string name)
        {
            string shakesPokemonDesc;
            try
            {
                var client = new System.Net.WebClient();
                //Get the pokemon data
                string pokeurl = "https://pokeapi.co/api/v2/pokemon/" + name.ToLower();
                dynamic pokemonData = JsonConvert.DeserializeObject(client.DownloadString(pokeurl));
                
                //Get the url of current pokemon species from pokemon data
                string pokemonSpeciesUrl = pokemonData.species.url.Value;
                dynamic pokemonSpeciesData = JsonConvert.DeserializeObject(client.DownloadString(pokemonSpeciesUrl));

                //Get the description from one of the flavor texts of pokemon species data.
                string realDesc = pokemonSpeciesData.flavor_text_entries[7].flavor_text;
                realDesc = Regex.Replace(realDesc, @"\t|\n|\r|\f", " ");

                //Use this description to get Shakespeare translation
                string shakesURL = "https://api.funtranslations.com/translate/shakespeare.json?text=" + realDesc;
                dynamic shakesPokemonData = JsonConvert.DeserializeObject(client.DownloadString(shakesURL));
                shakesPokemonDesc = shakesPokemonData.contents.translated.Value;
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            };
           
            return new Pokemon
            {
                Name = name,
                Description =  shakesPokemonDesc 
            };
        }
    }
}
