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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Refei��es"
                    },
                    new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Light"
                    },
                    new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Entradas"
                    },
                    new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Petiscos"
                    },
                    new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sobremesas"
                    }, new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bebidas"
                    }
                );

            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe);

            modelBuilder.Entity<Recipe>()
                .Navigation(r => r.Ratings)
                .AutoInclude();

        }
        public DbSet<ReceitasBE.Models.Category> Category { get; set; } = default!;
    }
}