namespace ReceitasBE.Models
{
    public class Ingredients{
        public Guid Id { get; set; }
        public Recipe Recipe { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
