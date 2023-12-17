using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReceitasBE.Models
{
    public class Ingredient{
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
