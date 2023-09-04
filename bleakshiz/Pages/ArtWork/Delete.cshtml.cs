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
    public class DeleteModel : PageModel
    {
        private readonly bleakshiz.Data.BleakshizArtContext _context;

        public DeleteModel(bleakshiz.Data.BleakshizArtContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Art == null)
            {
                return NotFound();
            }
            var art = await _context.Art.FindAsync(id);

            if (art != null)
            {
                Art = art;
                _context.Art.Remove(Art);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
