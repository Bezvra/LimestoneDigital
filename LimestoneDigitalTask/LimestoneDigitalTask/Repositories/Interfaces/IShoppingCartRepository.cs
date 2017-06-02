using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimestoneDigitalTask.Models.DTO;

namespace LimestoneDigitalTask.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        int CreateCart();
        int FindCartByEmail(string email);
        CartDTO GetCart(int cartId);
        void SavePromocode(int cartId, int promocodeId);
        void SaveEmail(int cartId, string email);
    }
}