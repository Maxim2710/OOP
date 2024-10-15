using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Interfaces
{
    public interface IUser
    {
        int Id { get; }

        string Username { get; }

        string Email { get; }

        bool IsAdmin { get; }
    }
}
