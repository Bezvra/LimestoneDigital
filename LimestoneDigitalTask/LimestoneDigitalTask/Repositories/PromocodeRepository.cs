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
    public class PromocodeRepository : BaseRepository, IPromocodeRepository
    {
        public PromocodeRepository(DbContext dbContext) : base(dbContext) { }


        public PromocodeInfoDTO GetPromocode(string code)
        {
            return db.Set<Promocode>().Where(promocode => promocode.code == code && promocode.is_used == false).Select(promocode => new PromocodeInfoDTO
            {
                Id = promocode.id,
                Code = promocode.code,
                ExpiresDate = promocode.expires_date,
                Count = promocode.count,
                UsedCount = promocode.used_count,
                Discount = promocode.discount
            }).FirstOrDefault();
            ;
        }

        public void UpdatePromocode(string code)
        {
            var updatedPromocode = db.Set<Promocode>().FirstOrDefault(promocode => promocode.code == code && promocode.is_used == false);
            if(updatedPromocode == null) throw new BaseException(Enums.Errors.EmptyData);
            updatedPromocode.count++;
            if (updatedPromocode.count > updatedPromocode.used_count)
            {
                updatedPromocode.is_used = true;
            }
        }
    }
}