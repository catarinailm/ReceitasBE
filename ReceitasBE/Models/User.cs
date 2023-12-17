using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReceitasBE.Models {
    public class User{
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email  { get; set; }
        [Required]
        public string Password  { get; set; }
        [Required]
        public int User_type { get; set; }
        public string Country { get; set; }
        public DateTime Birth_date { get; set; }
        public DateTime Data_created { get; set; }
        public DateTime Data_updated { get; set; }
        public DateTime Data_deleted { get; set; }
        public bool Deleted { get; set; }
        public bool Locked  { get; set; }
    }
}