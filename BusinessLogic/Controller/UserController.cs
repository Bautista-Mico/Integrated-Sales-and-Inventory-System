using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public (bool IsSuccess, string Message, User User) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return (false, "Username and Password cannot be empty.", null);
            }

            User user = _userRepository.Authenticate(username.Trim(), password.Trim());

            if (user == null)
            {
                return (false, "Invalid username or password.", null);
            }

            return (true, $"Welcome back, {user.Username}!", user);
        }
    }
}