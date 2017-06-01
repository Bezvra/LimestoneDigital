using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimestoneDigitalTask.Models.DTO;

namespace LimestoneDigitalTask.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<ShortProductInfoDTO> GetProducts();
        ProductInfoDTO GetProduct(int id);
    }
}
