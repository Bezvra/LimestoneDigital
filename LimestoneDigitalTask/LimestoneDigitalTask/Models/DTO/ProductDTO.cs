using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LimestoneDigitalTask.Models.DTO
{
    public class ShortProductInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int Discount { get; set; }
    }

    public class ProductInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Image { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int Discount { get; set; }
    }
}