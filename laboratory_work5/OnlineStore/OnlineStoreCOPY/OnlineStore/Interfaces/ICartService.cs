using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Interfaces
{
    public interface ICartService
    {
        void AddCart(ICart cart);
        ICart? GetCartByUser(IUser user);
    }
}
