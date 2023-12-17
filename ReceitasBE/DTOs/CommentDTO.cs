using ReceitasBE.Models;

namespace ReceitasBE.DTOs
{
    public class CommentDTO
    {
        public Guid RecipeId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
    }
}
