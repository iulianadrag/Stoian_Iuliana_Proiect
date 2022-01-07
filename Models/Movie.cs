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

        [Required, StringLength(120, MinimumLength = 2)]
        [Display(Name = "Titlu Film")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$"), Required,
StringLength(50, MinimumLength = 3)]
        public string Regizor { get; set; }
        [Display(Name = "Data Lansarii")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        public int StudioID { get; set; }        
        public Studio Studio { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
