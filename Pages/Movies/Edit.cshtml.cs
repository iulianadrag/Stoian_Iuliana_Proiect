using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stoian_Iuliana_Proiect.Data;
using Stoian_Iuliana_Proiect.Models;

namespace Stoian_Iuliana_Proiect.Pages.Movies
{
    public class EditModel : MovieCategoriesPageModel
    {
        private readonly Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext _context;

        public EditModel(Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.Include(b => b.Studio)
.Include(b => b.MovieCategories).ThenInclude(b => b.Category)
.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Movie);
            ViewData["StudioID"] = new SelectList(_context.Set<Studio>(), "ID", "StudioName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieToUpdate = await _context.Movie
.Include(i => i.Studio)
.Include(i => i.MovieCategories)
.ThenInclude(i => i.Category)
.FirstOrDefaultAsync(s => s.ID == id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(
movieToUpdate,
"Movie",
i => i.Title, i => i.Regizor,
i => i.ReleaseDate, i => i.Studio))
            {
                UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
            PopulateAssignedCategoryData(_context, movieToUpdate);
            return Page();

        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
