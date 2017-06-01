using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Models.DataBase;
using LimestoneDigitalTask.Models.DTO;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext) { }
        
        public List<ShortProductInfoDTO> GetProducts()
        {
            return db.Set<Product>().Select(product => new ShortProductInfoDTO
            {
                Id = product.id,
                Name = product.name,
                Price = product.price
            }).ToList();
        }

        public ProductInfoDTO GetProduct(int id)
        {
            return db.Set<Product>().Where(product => product.id == id).Select(product => new ProductInfoDTO
            {
                Id = product.id,
                Name = product.name,
                Price = product.price,
                Description = product.description
            }).FirstOrDefault();
        }
    }
}