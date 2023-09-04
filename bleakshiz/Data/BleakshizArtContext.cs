using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bleakshiz.Models;

namespace bleakshiz.Data
{
    public class BleakshizArtContext : DbContext
    {
        public BleakshizArtContext (DbContextOptions<BleakshizArtContext> options)
            : base(options)
        {
        }

        public DbSet<bleakshiz.Models.Art> Art { get; set; } = default!;
    }
}
