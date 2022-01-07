using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stoian_Iuliana_Proiect.Models
{
    public class Studio
    {
        public int ID { get; set; }
        [Display(Name = "Casa de Film")]
        public string StudioName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
