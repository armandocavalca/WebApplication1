using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class IndexModelBC : PageModel
    {
        private readonly AppDbContextTarghe _context;

        public IndexModelBC(AppDbContextTarghe context)
        {
            _context = context;
        }

        public IList<BC_Targhe> BC_Targhe { get;set; }

        public async Task OnGetAsync()
        {
            BC_Targhe = await _context.BC_Targhe.ToListAsync();
        }
    }
}
