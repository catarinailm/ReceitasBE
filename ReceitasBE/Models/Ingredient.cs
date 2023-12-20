using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ReceitasBE.Models
{
    public class Ingredient{
        [Key]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Recipe Recipe { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
