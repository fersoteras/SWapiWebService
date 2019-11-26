using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public class RatingModel
    {
        [Range(1,5)]
        public int Rating { get; set; }
    }
}



