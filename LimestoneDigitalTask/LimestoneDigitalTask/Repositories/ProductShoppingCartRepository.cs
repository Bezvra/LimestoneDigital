using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Repositories
{
    public class ProductShoppingCartRepository : BaseRepository, IProductShoppingCartRepository
    {
        public ProductShoppingCartRepository(DbContext dbContext) : base(dbContext) { }


    }
}