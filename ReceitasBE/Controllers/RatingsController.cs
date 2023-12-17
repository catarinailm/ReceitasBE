using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.Models;
using ReceitasBE.DTOs;
using ReceitasBE.Services;

namespace ReceitasBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly RatingsService _ratingsService;

        public RatingsController(RecipesDbContext context)
        {
            UsersService usersService = new UsersService(context);
            RecipesService recipesService = new RecipesService(context, usersService, new IngredientsService(context));
            _ratingsService = new RatingsService(context, recipesService);
        }

        // POST: api/Ratings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(RatingDTO ratingDTO)
        {
            Rating rating = _ratingsService.createRating(ratingDTO);

            return CreatedAtAction("GetRating", new { id = rating.Id }, rating);
        }

    }
}
