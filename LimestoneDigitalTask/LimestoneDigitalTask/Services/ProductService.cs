using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Helpers;
using LimestoneDigitalTask.Models.DTO;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Services
{
    public class ProductService
    {
        private IProductRepository productRepository { get; set; }
        private IImageRepository imageRepository { get; set; }
        private IPromocodeRepository promocodeRepository { get; set; }

        public ProductService(IProductRepository product, IImageRepository image, IPromocodeRepository promocode)
        {
            productRepository = product;
            imageRepository = image;
            promocodeRepository = promocode;
        }

        public List<ShortProductInfoDTO> GetProducts()
        {
            var products = productRepository.GetProducts();
            if (!products.Any()) return null;
            foreach (var product in products)
            {
                product.Image = imageRepository.GetImage(product.Id);
            }

            return products;
        }

        public List<ShortProductInfoDTO> GetProducts(string code)
        {
            var promocode = promocodeRepository.GetPromocode(code);
            if (promocode == null) throw new BaseException(Enums.Errors.EmptyData);
            if (promocode.ExpiresDate < DateTime.UtcNow) return GetProducts();
            if (promocode.Count <= promocode.UsedCount) return GetProducts();
            var products = GetProducts();
            foreach (var product in products)
            {
                product.SalePrice = product.Price - promocode.Discount * (product.Price / 100);
            }

            return products;
        }
    }
}