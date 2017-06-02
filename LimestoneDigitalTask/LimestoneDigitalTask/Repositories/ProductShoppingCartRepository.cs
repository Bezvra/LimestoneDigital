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

        public void DeleteProduct(int id)
        {
            var deletedProduct = db.Set<ProductsShoppingCart>().FirstOrDefault(product => product.id == id);
            if(deletedProduct == null) throw new BaseException(Enums.Errors.EmptyData);
            db.Set<ProductsShoppingCart>().Remove(deletedProduct);
            db.SaveChanges();
        }
    }
}