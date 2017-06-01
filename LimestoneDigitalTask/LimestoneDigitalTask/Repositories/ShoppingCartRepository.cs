using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Models.DataBase;
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
    }
}