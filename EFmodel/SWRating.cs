using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.EFmodel
{
    public class SWRating
    {
        public int ID { get; set; }

        [ Required ]
        public long CharacterId { get; set; }

        [Range(0, 5)]
        public int CharacterRating { get; set; }

        
    }
}
