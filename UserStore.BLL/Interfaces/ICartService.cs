using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.BLL.DTO;

namespace UserStore.BLL.Interfaces
{
   public interface ICartService
    {

        CartDTO GetById(int id);
        IEnumerable<CartDTO> GetAllUserProduct(string userEmail);
        void AddToCart(int id,string userId);
        void UpdateQuantity(int id,int quantity);
        void RemoveAllByUser(string userName);
        void RemoveProductFromCart(int Id);
        void Dispose();
    }
}
