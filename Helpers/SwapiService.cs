using Microsoft.Extensions.Configuration;
using SWRatingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WebApiService.EFmodel;
using WebApiService.Models;

namespace WebApiService.Helpers
{
    public class SwapiService : IExternalService
    {
        private IConfiguration _iconfiguration;
        private readonly string _swapiPath;
       


        public SwapiService(IConfiguration  iconfiguration )
        {
            _iconfiguration = iconfiguration;
            //retrieve swapi.co url from appsettings...
            _swapiPath = _iconfiguration.GetSection("swapiUrl").Value;
           
        }
        public async  Task<SWCharRootObject> PopulateCharacterData(int id)
        {
            var client = new HttpClient();

            
            // HTTP GET
            string url = String.Format("{0}/people/{1}", _swapiPath , id.ToString());
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(SWCharRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (SWCharRootObject)serializer.ReadObject(ms);

            return data;


        }

        public async  Task<SWPlanetRootObject> PopulatePlanetData(int id)
        {
            var client = new HttpClient();
            string url = String.Format("{0}/planets/{1}" , _swapiPath, id.ToString());
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(SWPlanetRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (SWPlanetRootObject)serializer.ReadObject(ms);

            return data;


        }

        public async  Task<string> GetSpeciesName(int id)
        {
            var client = new HttpClient();
            string url = String.Format("{0}/species/{1}", _swapiPath, id.ToString());
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(SWSpeciesRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (SWSpeciesRootObject)serializer.ReadObject(ms);

            return data.name;


        }

        // Combine data to conform a valid swcharacter view model
        public  SWCharacter GenerateNewCharacter(int id, SWCharRootObject charRoot, SWPlanetRootObject planetRoot)
        {
            SWCharacter character = new SWCharacter()
            {
                Id = id,
                Name = charRoot.name,
                Height = int.Parse(charRoot.height),
                Mass = float.Parse(charRoot.mass),
                Hair_Color = charRoot.hair_color,
                Skin_Color = charRoot.skin_color,
                Eye_Color = charRoot.eye_color,
                Birth_Year = charRoot.birth_year,
                Gender = charRoot.gender,
                HomeWorld = new SWHomeWorld() { Name = planetRoot.name, Population = planetRoot.population, Know_Residents_Count = planetRoot.residents.Count() },

                Species_Name = charRoot.species.First(),

                Average_Rating = 1,

                Max_Rating = 1

            };

            return character;

        }
    }
}
