using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LimestoneDigitalTask.Models.DTO
{
    public class MailCartDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class CartDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Promocode { get; set; }
        public List<ProductCartDTO> Products { get; set; }
        public decimal TotalSum { get; set; }
        public decimal SaleTotalSum { get; set; }
    }
}