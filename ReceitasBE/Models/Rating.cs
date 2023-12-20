using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ReceitasBE.Models
{
    public class Rating {
        [Key]
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        [JsonIgnore]
        public Recipe Recipe { get; set; }
        public int Value { get; set; }
    }
}

