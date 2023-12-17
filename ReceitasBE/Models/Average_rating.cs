namespace ReceitasBE.Models
{
    public class Average_rating {
        public Guid Id { get; set; }
        public Recipe Recipe { get; set; }
        public int Value { get; set; }
    }
}
