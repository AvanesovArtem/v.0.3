using System.Collections;
using System.Collections.Generic;
using UserStore.BLL.DTO;

namespace UserStore.BLL.Interfaces
{
   public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
        IEnumerable<ProductDTO> GetFirstN(int quantity);
        ProductDTO GetById(int id);
        void CreateProduct(UploadProductDTO item);
        void UpdateProduct(ProductDTO item);
        void RemoveProduct(int id);
        IEnumerable<ProductDTO> GetItemsPage(int page);
        IEnumerable GetProductsByName(string name); 
        void Dispose();

       
        
    }
}
