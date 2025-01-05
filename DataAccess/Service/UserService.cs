using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;

namespace DataAccess.Service
{
    public class UserService : UserBase, IUserService
    {
        private List<Users> _users;

        public const string SeedUsername = "admin";
        public const string SeedPassword = "password";

        public UserService()
        {
            _users = LoadUsers();

            if (!_users.Any())
            {
                _users.Add(new Users { Username = SeedUsername, Password = SeedPassword });
                SaveUsers(_users);
            }
        }

        public bool Login(Users user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }
            return _users.Any(u => u.Username == user.Username && u.Password == user.Password);
        }

        public static bool DeleteUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
