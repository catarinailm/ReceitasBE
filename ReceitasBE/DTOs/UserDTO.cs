namespace ReceitasBE.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int User_type { get; set; }
        public string Country { get; set; }
        public DateTime Birth_date { get; set; }
    }
}
