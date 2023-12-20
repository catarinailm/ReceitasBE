using System.ComponentModel.DataAnnotations;

namespace ReceitasBE.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<RecipeCategory> RecipeCategories { get; }
    }
}
