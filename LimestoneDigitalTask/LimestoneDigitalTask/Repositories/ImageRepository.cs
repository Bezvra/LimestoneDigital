using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Models.DataBase;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(DbContext dbContext) : base(dbContext) { }
        
        public string GetImage(int id)
        {
            return db.Set<Image>().Where(image => image.product_id == id).Select(image => image.url).FirstOrDefault();
        }

        public List<string> GetImages(int id)
        {
            return db.Set<Image>().Where(image => image.product_id == id).Select(image => image.url).ToList();
        }
    }
}