using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stoian_Iuliana_Proiect.Data;
using Stoian_Iuliana_Proiect.Models;

namespace Stoian_Iuliana_Proiect.Pages.Movies
{
    public class CreateModel : MovieCategoriesPageModel
    {
        private readonly Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext _context;

        public CreateModel(Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StudioID"] = new SelectList(_context.Set<Studio>(), "ID", "StudioName");
            var movie = new Movie();
            movie.MovieCategories = new List<MovieCategory>();
            PopulateAssignedCategoryData(_context, movie);
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMovie = new Movie();
            if (selectedCategories != null)
            {
                newMovie.MovieCategories = new List<MovieCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MovieCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMovie.MovieCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Movie>(
newMovie,
"Movie",
i => i.Title, i => i.Regizor,
 i => i.ReleaseDate, i => i.StudioID))
            {
                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMovie);
            return Page();
        }
    }
    
}
