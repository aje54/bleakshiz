using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bleakshiz.Data;
using bleakshiz.Models;

namespace bleakshiz.Pages.ArtWork
{
    public class DetailsModel : PageModel
    {
        private readonly bleakshiz.Data.BleakshizArtContext _context;

        public DetailsModel(bleakshiz.Data.BleakshizArtContext context)
        {
            _context = context;
        }

      public Art Art { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Art == null)
            {
                return NotFound();
            }

            var art = await _context.Art.FirstOrDefaultAsync(m => m.Id == id);
            if (art == null)
            {
                return NotFound();
            }
            else 
            {
                Art = art;
            }
            return Page();
        }
    }
}
