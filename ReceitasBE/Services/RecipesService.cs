using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using ReceitasBE.Data;
using ReceitasBE.DTOs;
using ReceitasBE.Models;

namespace ReceitasBE.Services
{
    public class RecipesService
    {

        private readonly RecipesDbContext _context;
        private readonly UsersService _usersService;
        private readonly IngredientsService _ingredientsService;

        public RecipesService(RecipesDbContext recipesDbContext, UsersService usersService, IngredientsService ingredientsService) 
        {
            _context = recipesDbContext;
            _usersService = usersService;
            _ingredientsService = ingredientsService;
        }

        public Recipe createRecipe(CreateRecipeDTO recipeDTO)
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
            recipe.Ingredients = recipeDTO.Ingredients.Select(ingredientDTO => _ingredientsService.createIngredient(ingredientDTO)).ToList();

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return recipe;
        }

        public IEnumerable<RecipeDTO> GetAllRecipes()
        {
            return _context.Recipes.Select(recipe => toRecipeDTO(recipe)).ToList();
        }

        public RecipeDTO GetRecipe(Guid id)
        {
            return toRecipeDTO(findRecipeById(id));
        }

        private RecipeDTO toRecipeDTO(Recipe recipe)
        {
            RecipeDTO recipeDTO = new RecipeDTO();
            recipeDTO.Id = recipe.Id;
            recipeDTO.Name = recipe.Name;
            recipeDTO.User = recipe.User;
            recipeDTO.Duration = recipe.Duration;
            recipeDTO.Difficulty = recipe.Difficulty;
            recipeDTO.Procedure = recipe.Procedure;
            recipeDTO.Image_name = recipe.Image_name;
            recipeDTO.Ingredients = recipe.Ingredients;
            recipeDTO.AverageRating = recipe.Ratings.Select(rating => rating.Value).Average();  

            return recipeDTO;
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
