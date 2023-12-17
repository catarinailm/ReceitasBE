using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.DTOs;
using ReceitasBE.Models;

namespace ReceitasBE.Services
{
    public class RecipesService
    {

        private readonly RecipesDbContext _context;
        private readonly UsersService _usersService;

        public RecipesService(RecipesDbContext recipesDbContext, UsersService usersService) 
        {
            _context = recipesDbContext;
            _usersService = usersService;
        }

        public Recipe createRecipe(RecipeDTO recipeDTO)
        {
            User user = _usersService.findUserById(recipeDTO.UserId);
            Recipe recipe = new Recipe();

            recipe.Name = recipeDTO.Name;
            recipe.Duration = recipeDTO.Duration;
            recipe.Difficulty = recipeDTO.Difficulty;
            recipe.Procedure = recipeDTO.Procedure;
            recipe.Image_name = recipeDTO.Image_name;

            recipe.Id = Guid.NewGuid();
            recipe.User = user;
            recipe.Data_created = DateTime.Now;
            recipe.Data_updated = DateTime.Now;
            recipe.Deleted = false;
            recipe.Approved = false;

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return recipe;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe findRecipeById(Guid id)
        {
            return _context.Recipes.Find(id);
        }

        public Recipe deleteRecipe(Guid id)
        {
            Recipe recipe = findRecipeById(id);

            if (recipe != null)
            {
                recipe.Deleted=true;

                _context.Entry(recipe).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return recipe;
        }

        public Recipe approveRecipe(Guid id)
        {
            Recipe recipe = findRecipeById(id);

            if (recipe != null)
            {
                recipe.Approved = true;

                _context.Entry(recipe).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return recipe;
        }
    }
}
