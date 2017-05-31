using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LimestoneDigitalTask.Models.DTO
{
    public class PromocodeInfoDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Count { get; set; }
        public int UsedCount { get; set; }
        public DateTime ExpiresDate { get; set; }
    }
}