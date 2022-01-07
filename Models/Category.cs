using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stoian_Iuliana_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Categorii")]
        public string CategoryName { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
