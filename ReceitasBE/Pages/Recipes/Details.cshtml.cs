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
    public class DetailsModel : PageModel
    {
        private readonly ReceitasBE.Data.RecipesDbContext _context;

        public DetailsModel(ReceitasBE.Data.RecipesDbContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            else
            {
                Recipe = recipe;
            }
            return Page();
        }
    }
}
