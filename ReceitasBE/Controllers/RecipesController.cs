using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.DTOs;
using ReceitasBE.Models;
using ReceitasBE.Services;

namespace ReceitasBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;

        public RecipesController(RecipesDbContext context)
        {
            _recipesService = new RecipesService(context, new UsersService(context), new IngredientsService(context));
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipes()
        {
            return Ok(_recipesService.GetAllRecipes());
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(Guid id)
        {
            var recipe = _recipesService.GetRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(Guid id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(CreateRecipeDTO recipeDTO)
        {
           Recipe recipe = _recipesService.createRecipe(recipeDTO);

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            var recipe = _recipesService.deleteRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // PUT: api/Recipes/5/approve
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveRecipe(Guid id)
        {
            var recipe = _recipesService.approveRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
