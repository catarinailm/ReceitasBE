using ReceitasBE.Models;

namespace ReceitasBE.DTOs
{
    public class RecipeDTO
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public string Procedure { get; set; }
        public string Image_name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double AverageRating { get; set; }
    }
}
