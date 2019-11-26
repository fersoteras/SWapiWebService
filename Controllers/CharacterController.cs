using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWRatingApp.Models;
using WebApiService.Helpers;
using WebApiService.Models;
using WebApiService.EFmodel;
using System.Net.Http;
using System.Net;
using Microsoft.Extensions.Caching.Memory;
using WebApiService.Cache;

namespace WebApiService.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IExternalService _swapiService;
        private readonly IRatingService _ratingService;
        private readonly SWratingsContext _context;
        private  MemoryCache _cache;

        private static readonly List<SWCharacter> _charactersInMemoryStore = new List<SWCharacter>();

        //constructor , initializa cache
        public CharacterController(IExternalService swapiService, IRatingService ratingService, SWratingsContext context , SWCharacterMemoryCache memoryCache)
        {
            _context = context;
            _swapiService = swapiService;
            _ratingService = ratingService;
            _cache = memoryCache.Cache;

        }
        // get all characters in cache.
        [HttpGet]
        public ActionResult<List<SWCharacter>> GetAll() => _charactersInMemoryStore;


        //   GET /character/<id>/
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SWCharacter>> GetById(int id)
        {
            // invalid parameter passed case
            if(id < 1 )
            {
                return NotFound();
            }
            SWCharacter myCharacter;
            //access cache
            if (!_cache.TryGetValue(id, out SWCharacter characterCacheEntry))
            {
                //entity not stored in cache , retrieve and cache it.
                //...
                SWCharRootObject myChar = await _swapiService.PopulateCharacterData(id);

                // retrieve character's planet data , extract id from character root object  homeplanet slot.

                string planetId = Regex.Match(myChar.homeworld, @"\d+").Value;

                SWPlanetRootObject itsPlanet = await _swapiService.PopulatePlanetData(int.Parse(planetId));

                //Generate a Character viewModel using populated data from swapi...

                 myCharacter = _swapiService.GenerateNewCharacter(id, myChar, itsPlanet);

                //replace path to species with  species name

                string speciesId = Regex.Match(myCharacter.Species_Name, @"\d+").Value;

                myCharacter.Species_Name = await _swapiService.GetSpeciesName(int.Parse(speciesId));

                myCharacter.Average_Rating = 1;
                myCharacter.Max_Rating = 1;

                //generate options required by memcache module...
                var cacheEntryOptions = new MemoryCacheEntryOptions()
              // Set cache entry size by extension method.
              .SetSize(1)
              // Keep in cache for this time, reset time if accessed.
              .SetSlidingExpiration(TimeSpan.FromSeconds(3600));

                // finaly , store it in memcache...
                _cache.Set(id, myCharacter, cacheEntryOptions);
            }
            else
            {
                // cache entry found...
                myCharacter = characterCacheEntry;
            }
           


                if (myCharacter == null)
                {
                    return NotFound();
                }
                else
                {
                    return myCharacter;
                }

            }

        


        //POST /character/<id>/rating/
        [HttpPost("{id}/rating")]
        public HttpResponseMessage CreateRating(int id, [FromBody] RatingModel rating)
        {

            if (ModelState.IsValid)
            {
                _context.Add(new SWRating() { CharacterId = id, CharacterRating = rating.Rating });
                _context.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }
    }

}