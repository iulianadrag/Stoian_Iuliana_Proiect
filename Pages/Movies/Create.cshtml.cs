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
    public class CreateModel : PageModel
    {
        private readonly Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext _context;

        public CreateModel(Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StudioID"] = new SelectList(_context.Set<Studio>(), "ID", "StudioName");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
