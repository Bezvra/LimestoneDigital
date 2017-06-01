using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Services
{
    public class CartService
    {
        private IProductRepository productRepository { get; set; }
        private IPromocodeRepository promocodeRepository { get; set; }
        private IShoppingCartRepository cartRepository { get; set; }
        private IProductShoppingCartRepository productCartRepository { get; set; }

        public CartService(IProductRepository product, IPromocodeRepository promocode, IShoppingCartRepository cart, IProductShoppingCartRepository productCart)
        {
            productRepository = product;
            promocodeRepository = promocode;
            cartRepository = cart;
            productCartRepository = productCart;
        }

        public int CreateCart(int productId)
        {
            var cartId = cartRepository.CreateCart();
            AddToCart(cartId, productId);

            return cartId;
        }

        public int FindCartByEmail(string email, int productId)
        {
            var cartId = cartRepository.FindCartByEmail(email);
            if (cartId == 0) cartId = CreateCart(productId);
            else AddToCart(cartId, productId);

            return cartId;
        }

        public void AddToCart(int cartId, int productId)
        {
            productCartRepository.AddToCart(cartId, productId);
        }
    }
}