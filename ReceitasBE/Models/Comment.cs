using System.ComponentModel.DataAnnotations;

namespace ReceitasBE.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Recipe Recipe { get; set; }
        [Required]
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime Date_created { get; set; }
        public DateTime Date_updated { get; set; }
        public DateTime Date_deleted { get; set; }
        public bool deleted { get; set; }
    }
}
