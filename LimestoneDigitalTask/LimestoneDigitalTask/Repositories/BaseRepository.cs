using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LimestoneDigitalTask.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected DbContext db { get; set; }

        public BaseRepository(DbContext dbContext)
        {
            db = dbContext;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}