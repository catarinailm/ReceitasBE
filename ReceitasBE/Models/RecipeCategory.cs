using System.ComponentModel.DataAnnotations;

namespace ReceitasBE.Models
{
    public class RecipeCategory
    {
        [Key]
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public Category Category { get; set; }
    }
}
