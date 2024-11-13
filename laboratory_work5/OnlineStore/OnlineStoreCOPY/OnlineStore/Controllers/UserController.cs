using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class UserController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public void RegisterUser(string username, string email, bool isAdmin = false)
        {
            var user = new User(username, email, isAdmin);
            _userService.RegisterUser(user);
        }

        public IUser? GetUserByUsername(string username)
        {
            return _userService.GetUserByUsername(username);
        }
    }
}
