using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class DetailsModelBC : PageModel
    {
        private readonly AppDbContextTarghe _context;

        public DetailsModelBC(AppDbContextTarghe context)
        {
            _context = context;
        }

        public BC_Targhe BC_Targhe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BC_Targhe = await _context.BC_Targhe.FirstOrDefaultAsync(m => m.Id == id);

            if (BC_Targhe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
