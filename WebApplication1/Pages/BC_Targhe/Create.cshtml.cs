using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1
{
    public class CreateModelBC : PageModel
    {
        private readonly AppDbContextTarghe _context;

        public CreateModelBC(AppDbContextTarghe context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BC_Targhe BC_Targhe { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BC_Targhe.Add(BC_Targhe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}