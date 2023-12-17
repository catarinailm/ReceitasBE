using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.DTOs;
using ReceitasBE.Models;

namespace ReceitasBE.Services
{
    public class IngredientsService
    {
        private readonly RecipesDbContext _context;

        public IngredientsService(RecipesDbContext context) 
        {
            _context = context;
        }

        public Ingredient createIngredient(IngredientDTO ingredientDTO)
        {
            Ingredient ingredient = new Ingredient();

            ingredient.Id = new Guid();
            ingredient.Amount = ingredientDTO.Amount;
            ingredient.Name = ingredientDTO.Name;

            return ingredient;
        }
    }
}
