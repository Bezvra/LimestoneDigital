using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Repositories
{
    public class PromocodeRepository : BaseRepository, IPromocodeRepository
    {
        public PromocodeRepository(DbContext dbContext) : base(dbContext) { }


    }
}