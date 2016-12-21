using System.Collections.Generic;
using UserStore.BLL.DTO;

namespace UserStore.BLL.Interfaces
{
   public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAll();
        void Create(UploadOrderDTO order,string userName);
        void RemoveAll(int userId);


    }
}
