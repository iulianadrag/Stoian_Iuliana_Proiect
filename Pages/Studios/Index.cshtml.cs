using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stoian_Iuliana_Proiect.Data;
using Stoian_Iuliana_Proiect.Models;

namespace Stoian_Iuliana_Proiect.Pages.Studios
{
    public class IndexModel : PageModel
    {
        private readonly Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext _context;

        public IndexModel(Stoian_Iuliana_Proiect.Data.Stoian_Iuliana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Studio> Studio { get;set; }

        public async Task OnGetAsync()
        {
            Studio = await _context.Studio.ToListAsync();
        }
    }
}
