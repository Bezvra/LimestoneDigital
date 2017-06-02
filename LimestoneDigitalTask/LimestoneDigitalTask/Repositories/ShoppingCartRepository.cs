using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Helpers;
using LimestoneDigitalTask.Models.DataBase;
using LimestoneDigitalTask.Models.DTO;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Repositories
{
    public class ShoppingCartRepository : BaseRepository, IShoppingCartRepository
    {
        public ShoppingCartRepository(DbContext dbContext) : base(dbContext) { }
        
        public int CreateCart()
        {
            var cart = new ShoppingCart
            {
                promocode_id = null,
                email = null,
                is_closed = false
            };
            db.Set<ShoppingCart>().Add(cart);
            db.SaveChanges();

            return cart.id;
        }

        public int FindCartByEmail(string email)
        {
            return db.Set<ShoppingCart>().Where(cart => cart.email == email && cart.is_closed == false).Select(cart => cart.id).FirstOrDefault();
        }

        public CartDTO GetCart(int cartId)
        {
            return db.Set<ShoppingCart>().Where(cart => cart.id == cartId && cart.is_closed == false).Select(cart => new CartDTO
            {
                Id = cart.id,
                Email = cart.email,
                Promocode = cart.Promocode.code,
                Products = cart.ProductsShoppingCarts.Select(product => new ProductCartDTO
                {
                    Id = product.id,
                    Name = product.Product.name,
                    Price = product.Product.price
                }).ToList()
            }).FirstOrDefault();
        }

        public void SavePromocode(int cartId, int promocodeId)
        {
            var updatedCart = db.Set<ShoppingCart>().FirstOrDefault(cart => cart.id == cartId && cart.is_closed == false);
            if(updatedCart == null) throw new BaseException(Enums.Errors.EmptyData);
            updatedCart.promocode_id = promocodeId;
            db.SaveChanges();
        }

        public void SaveEmail(int cartId, string email)
        {
            var updatedCart = db.Set<ShoppingCart>().FirstOrDefault(cart => cart.id == cartId && cart.is_closed == false);
            if (updatedCart == null) throw new BaseException(Enums.Errors.EmptyData);
            updatedCart.email = email;
            db.SaveChanges();
        }

        public void CloseCart(int cartId)
        {
            var closedCart = db.Set<ShoppingCart>().FirstOrDefault(cart => cart.id == cartId && cart.is_closed == false);
            if (closedCart == null) throw new BaseException(Enums.Errors.EmptyData);
            closedCart.is_closed = true;
            db.SaveChanges();
        }
    }
}