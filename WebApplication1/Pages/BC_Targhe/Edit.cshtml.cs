using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class EditModelBC : PageModel
    {
        private readonly AppDbContextTarghe _context;

        public EditModelBC(AppDbContextTarghe context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BC_Targhe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BC_TargheExists(BC_Targhe.Id))
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

        private bool BC_TargheExists(int id)
        {
            return _context.BC_Targhe.Any(e => e.Id == id);
        }
    }
}
