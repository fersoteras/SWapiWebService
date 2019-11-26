using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWRatingApp.Models
{
    public class SWCharacter
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public float Mass { get; set; }

        public string Hair_Color { get; set; }

        public string Skin_Color { get; set; }

        public string  Eye_Color { get; set; }

        public string Birth_Year { get; set; }

        public string Gender { get; set; }

        public SWHomeWorld  HomeWorld { get; set; }

        public string Species_Name { get; set; }

        public float Average_Rating { get; set; }

        public int Max_Rating { get; set; }







    }
}
