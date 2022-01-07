using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stoian_Iuliana_Proiect.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name = "Titlu Film")]
        public string Title { get; set; }
        public string Regizor { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int StudioID { get; set; }
        public Studio Studio { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
