using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Models.DataBase;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Repositories
{
    public class ProductShoppingCartRepository : BaseRepository, IProductShoppingCartRepository
    {
        public ProductShoppingCartRepository(DbContext dbContext) : base(dbContext) { }
        
        public void AddToCart(int cartId, int productId)
        {
            db.Set<ProductsShoppingCart>().Add(new ProductsShoppingCart
            {
                cart_id = cartId,
                product_id = productId
            });
            db.SaveChanges();
        }
    }
}