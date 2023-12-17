using ReceitasBE.Models;

namespace ReceitasBE.DTOs
{
    public class CreateRecipeDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public string Procedure { get; set; }
        public string Image_name { get; set; }
        public IEnumerable<IngredientDTO> Ingredients { get; set;}
    }

}
