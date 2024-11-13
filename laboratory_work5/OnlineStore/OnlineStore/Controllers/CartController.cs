using OnlineStore.Interfaces;
using OnlineStore.Models;
using System.Collections.Generic;

namespace OnlineStore.Controllers
{
    public class CartController
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public void CreateCartForUser(IUser user)
        {
            var cart = new Cart(user);
            _cartService.AddCart(cart);
        }

        public void AddProductToUserCart(IUser user, IProduct product)
        {
            var cart = _cartService.GetCartByUser(user) ?? new Cart(user);
            cart.AddProduct(product);
            _cartService.AddCart(cart); // Ensure cart is added
        }

        public void RemoveProductFromUserCart(IUser user, IProduct product)
        {
            var cart = _cartService.GetCartByUser(user);
            cart?.RemoveProduct(product);
        }

        public decimal GetCartTotal(IUser user)
        {
            var cart = _cartService.GetCartByUser(user);
            return cart?.GetTotalPrice() ?? 0;
        }

        public List<IProduct> GetCartProducts(IUser user)
        {
            var cart = _cartService.GetCartByUser(user);
            return cart?.Products ?? new List<IProduct>();
        }
    }
}
