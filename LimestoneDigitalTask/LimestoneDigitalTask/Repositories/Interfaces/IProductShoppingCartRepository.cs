using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimestoneDigitalTask.Repositories.Interfaces
{
    public interface IProductShoppingCartRepository
    {
        void AddToCart(int cartId, int productId);
    }
}
