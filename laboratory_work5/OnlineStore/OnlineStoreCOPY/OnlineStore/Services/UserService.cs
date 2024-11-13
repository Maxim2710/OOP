using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public class UserService : IUserService
    {
        private List<IUser> _users;

        public UserService()
        {
            _users = new List<IUser>();
        }

        public void RegisterUser(IUser user)
        {
            _users.Add(user);
        }

        public IUser? GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}
