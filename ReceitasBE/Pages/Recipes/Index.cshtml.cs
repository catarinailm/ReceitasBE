using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.Models;

namespace ReceitasBE.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly ReceitasBE.Data.RecipesDbContext _context;

        public IndexModel(ReceitasBE.Data.RecipesDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes.ToListAsync();
        }
    }
}
