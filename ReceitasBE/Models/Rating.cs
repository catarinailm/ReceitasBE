using System.ComponentModel.DataAnnotations;


namespace ReceitasBE.Models
{
    public class Rating {
        [Key]
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public int Value { get; set; }
    }
}

