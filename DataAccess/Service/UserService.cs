using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;

namespace DataAccess.Service
{
    public class UserService : UserBase, IUserService // Inherits UserBase and implement IUserService interface
    {
        private List<Users> _users; // Field to hold the users list

        // Seeding username and password
        public const string SeedUsername = "admin";
        public const string SeedPassword = "password";

        public UserService() // Initializing Constructor
        {
            _users = LoadUsers(); // Loading existing users

            if (!_users.Any())
            {
                _users.Add(new Users { Username = SeedUsername, Password = SeedPassword }); // Creating a default admin user
                SaveUsers(_users); // Save and update user list
            }
        }

        public bool Login(Users user) // Method to handle user login
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }
            return _users.Any(u => u.Username == user.Username && u.Password == user.Password);
        }
    }
}
