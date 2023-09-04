using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using bleakshiz.Data;
using bleakshiz.Models;

namespace bleakshiz.Pages.ArtWork
{
    public class CreateModel : PageModel
    {
        private readonly bleakshiz.Data.BleakshizArtContext _context;

        public CreateModel(bleakshiz.Data.BleakshizArtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Art Art { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Art == null || Art == null)
            {
                return Page();
            }

            _context.Art.Add(Art);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
