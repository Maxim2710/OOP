using OnlineStore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Services
{
    public class CartService : ICartService
    {
        private List<ICart> _carts;

        public CartService()
        {
            _carts = new List<ICart>();
        }

        public void AddCart(ICart cart)
        {
            _carts.Add(cart);
        }

        public ICart? GetCartByUser(IUser user)
        {
            return _carts.FirstOrDefault(c => c.User.Username == user.Username);
        }
    }
}
