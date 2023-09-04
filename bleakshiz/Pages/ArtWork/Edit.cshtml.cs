using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bleakshiz.Data;
using bleakshiz.Models;

namespace bleakshiz.Pages.ArtWork
{
    public class EditModel : PageModel
    {
        private readonly bleakshiz.Data.BleakshizArtContext _context;

        public EditModel(bleakshiz.Data.BleakshizArtContext context)
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

            var art =  await _context.Art.FirstOrDefaultAsync(m => m.Id == id);
            if (art == null)
            {
                return NotFound();
            }
            Art = art;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Art).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtExists(Art.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArtExists(int id)
        {
          return (_context.Art?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
