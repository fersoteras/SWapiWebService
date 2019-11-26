using SWRatingApp.Models;
using System.Threading.Tasks;
using WebApiService.Models;

namespace WebApiService.Helpers
{
    public interface IExternalService
    {
       public Task<SWCharRootObject> PopulateCharacterData(int id);
       public Task<SWPlanetRootObject> PopulatePlanetData(int id);
        public Task<string> GetSpeciesName(int id);
        public SWCharacter GenerateNewCharacter(int id, SWCharRootObject charRoot, SWPlanetRootObject planetRoot);
    }
}