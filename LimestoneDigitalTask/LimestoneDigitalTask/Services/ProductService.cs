using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LimestoneDigitalTask.Models.DTO;
using LimestoneDigitalTask.Repositories.Interfaces;

namespace LimestoneDigitalTask.Services
{
    public class ProductService
    {
        private IProductRepository productRepository { get; set; }
        private IImageRepository imageRepository { get; set; }

        public ProductService(IProductRepository product, IImageRepository image)
        {
            productRepository = product;
            imageRepository = image;
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
    }
}