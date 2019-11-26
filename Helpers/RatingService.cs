using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiService.EFmodel;

namespace WebApiService.Helpers
{
    public class RatingService : IRatingService
    {
        private readonly SWratingsContext _context;

        public RatingService(SWratingsContext context)
        {
            _context = context;
        }
        public  float GetAvgRating(int id)
        {
            float avgrating;

            using (_context)
            {
                // identify max rating if ther is one...
                // filter ratings for id ...

                var entities = from b in _context.Ratings
                               where b.CharacterId == id
                               select b;

                // calculate new avg.
                avgrating  = (float)entities.Average(c => c.CharacterRating);
            }

            return (avgrating > 0) ? avgrating : 1;


        }
        //extract Max rating or return 0;
        public  int GetMaxRating(int id)
        {
            int maxRating;
            using (var db = new SWratingsContext())
            {
                // identify max rating if ther is one...
                // filter ratings for id ...

                var entities = from b in db.Ratings
                               where b.CharacterId == id
                               select b;

                // query max.
                if (entities.Any())
                {
                    maxRating = entities.Max(p => p.CharacterRating);
                }
                else
                {
                    maxRating = 1;
                }
            }

            return (maxRating > 0) ? maxRating : 1 ;
        }
    }
}
