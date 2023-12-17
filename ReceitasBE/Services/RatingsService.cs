using ReceitasBE.Data;
using ReceitasBE.DTOs;
using ReceitasBE.Models;

namespace ReceitasBE.Services
{
    public class RatingsService
    {
        private readonly RecipesDbContext _context;
        private readonly RecipesService _recipesService;

        public RatingsService(RecipesDbContext recipesDbContext, RecipesService recipesService)
        {
            _context = recipesDbContext;
            _recipesService = recipesService;
        }

        public Rating createRating(RatingDTO ratingDTO)
        {
            Recipe recipe = _recipesService.findRecipeById(ratingDTO.RecipeId);
            Rating rating = new Rating();

            rating.Value = ratingDTO.Value;

            rating.Id = Guid.NewGuid();
            rating.RecipeId = recipe.Id;

            _context.Rating.Add(rating);
            _context.SaveChanges();

            return rating;

        }

    }
}
