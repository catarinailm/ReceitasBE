using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.DTOs;
using ReceitasBE.Models;

namespace ReceitasBE.Services
{
    public class UsersService
    {
        private readonly RecipesDbContext _context;

        public UsersService(RecipesDbContext context)
        {
            _context = context;
        }

        public User createUser(UserDTO userDTO)
        {
            if (UserExists(userDTO.Username)) 
            {
                throw new Exception();
            }

            User user = new User();

            user.Username = userDTO.Username;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.User_type = userDTO.User_type;
            user.Country = userDTO.Country;
            user.Birth_date = userDTO.Birth_date;

            user.Id = Guid.NewGuid();
            user.Data_created = DateTime.Now;
            user.Data_updated = DateTime.Now;
            user.Deleted = false;
            user.Locked = false;

            _context.Users.Add(user);
            _context.SaveChangesAsync();

            return user;
        }

        public User findUserById(Guid id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                // Lançar excepção
            }

            return user;
        }

        private bool UserExists(String username)
        {
            return _context.Users.Any(e => e.Username == username);
        }

        public bool login(LoginDTO loginDTO)
        {
            User user = findUserByUsername(loginDTO.Username);

            return user.Password.Equals(loginDTO.Password);
        }

        private User findUserByUsername(String username)
        {
            var user = _context.Users.Single(user => user.Username == username);

            if (user == null)
            {
                // Lançar excepção
            }
            
            return user;
        }
    }
}
