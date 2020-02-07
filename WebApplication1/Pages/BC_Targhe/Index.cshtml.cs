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
    public class IndexModelBC : PageModel
    {
        private readonly AppDbContextTarghe _context;

        public IndexModelBC(AppDbContextTarghe context)
        {
            _context = context;
        }

        public IList<BC_Targhe> BC_Targhe { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Targhe { get; set; }
        [BindProperty(SupportsGet = true)]
        public string targhe { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.BC_Targhe
                                            orderby m.bc_targa
                                            select m.bc_targa;
            var bc_targhe = from m in _context.BC_Targhe
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                bc_targhe = bc_targhe.Where(s => s.bc_targa.Contains(SearchString));
            }
            Targhe = new SelectList(await genreQuery.Distinct().ToListAsync());
            BC_Targhe = await bc_targhe.ToListAsync();
        }
    }
}
