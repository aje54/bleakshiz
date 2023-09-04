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
    public class IndexModel : PageModel
    {
        private readonly bleakshiz.Data.BleakshizArtContext _context;

        public IndexModel(bleakshiz.Data.BleakshizArtContext context)
        {
            _context = context;
        }

        public IList<Art> Art { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Art != null)
            {
                Art = await _context.Art.ToListAsync();
            }
        }
    }
}
