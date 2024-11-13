using OnlineStore.Interfaces;

namespace OnlineStore.Models
{
    public class User : IUser
    {
        private static int _idCounter = 0; // Статический счетчик для уникальных ID
        private int _id; // ID пользователя
        private string _username;
        private string _email;
        private bool _isAdmin;

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public string Username
        {
            get => _username;
            private set => _username = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            private set => _isAdmin = value;
        }

        public User(string username, string email, bool isAdmin = false)
        {
            _id = ++_idCounter; // Увеличиваем счетчик и присваиваем ID
            _username = username;
            _email = email;
            _isAdmin = isAdmin;
        }
    }
}
