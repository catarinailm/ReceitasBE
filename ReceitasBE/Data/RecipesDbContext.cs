using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReceitasBE.Models;

namespace ReceitasBE.Data
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext(DbContextOptions options): base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<Recipe> Recipes { get; set; } = default!;
        public virtual DbSet<Comment> Comment { get; set; } = default!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = default!;
        public virtual DbSet<Rating> Rating { get; set; } = default!;
    }
}