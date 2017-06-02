using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Helpers;
using LimestoneDigitalTask.Models.DTO;
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

        public CartDTO GetCart(int cartId)
        {
            var cart = cartRepository.GetCart(cartId);
            if (cart == null) return null;
            if (cart.Promocode != null)
            {
                var saleSum = 0m;
                var sum = 0m;
                var promocode = promocodeRepository.GetPromocode(cart.Promocode);
                if (promocode == null) return cart;
                if (promocode.ExpiresDate < DateTime.UtcNow) return cart;
                if (promocode.Count <= promocode.UsedCount) return cart;
                foreach (var product in cart.Products)
                {
                    product.SalePrice = product.Price - promocode.Discount * (product.Price / 100);
                    product.Discount = promocode.Discount;
                    saleSum += product.SalePrice;
                    sum += product.Price;
                }
                cart.SaleTotalSum = saleSum;
                cart.TotalSum = sum;
            }
            else
            {
                var sum = 0m;
                foreach (var product in cart.Products)
                {
                    sum += product.Price;
                }
                cart.TotalSum = sum;
            }
            return cart;
        }

        public void SaveEmail(int cartId, string email)
        {
            cartRepository.SaveEmail(cartId, email);
        }

        public void SavePromocode(int cartId, string code)
        {
            var promocode = promocodeRepository.GetPromocode(code);
            if (promocode == null) throw new BaseException(Enums.Errors.EmptyData);
            if (promocode.ExpiresDate < DateTime.UtcNow) throw new BaseException(Enums.Errors.NotConfirm);
            if (promocode.Count <= promocode.UsedCount) throw new BaseException(Enums.Errors.NotConfirm);
            cartRepository.SavePromocode(cartId, promocode.Id);
        }

        public CartDTO GetCart(int cartId, string code)
        {
            var promocode = promocodeRepository.GetPromocode(code);
            if (promocode == null) return GetCart(cartId);
            if (promocode.ExpiresDate < DateTime.UtcNow) return GetCart(cartId);
            if (promocode.Count <= promocode.UsedCount) return GetCart(cartId);
            cartRepository.SavePromocode(cartId, promocode.Id);

            return GetCart(cartId);
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

        public void DeleteProduct(int id)
        {
            productCartRepository.DeleteProduct(id);
        }
    }
}