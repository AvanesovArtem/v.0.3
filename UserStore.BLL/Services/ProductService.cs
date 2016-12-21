using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Entities;
using UserStore.DAL.Interfaces;

namespace UserStore.BLL.Services
{
    public class ProductService:IProductService
    {
        private IUnitOfWork Uow { get; set;}
       
        public ProductService(IUnitOfWork db)
        {
      
            Uow = db;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product,ProductDTO>());
            var product = Uow.Products.GetAll().ToList();
            var productDto = Mapper.Map<IEnumerable<Product>,List<ProductDTO>>(product);
            return productDto;
        }

        public IEnumerable<ProductDTO> GetFirstN(int quantity)
        {
            return GetAll();
            //IEnumerable<Product> product = Uow.Products.GetAll();
            //Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());

            //return Mapper.Map<IEnumerable<Product>, IList<ProductDTO>>(product);
        }

        public ProductDTO GetById(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            var product = Uow.Products.GetById(id);
            var productDto = Mapper.Map<Product,ProductDTO>(product);
            return productDto;
        }

        public void CreateProduct(UploadProductDTO item)
        {
            string path = LocalUploader.SaveImage(item.Image, item.Absolutepath, item.Name);

            item.Absolutepath = path;
            Mapper.Initialize(cfg => cfg.CreateMap<UploadProductDTO, Product>());
            var productDto = Mapper.Map<UploadProductDTO, Product>(item);
            Uow.Products.Create(productDto);
            Uow.Save();
        }

        public void UpdateProduct(ProductDTO item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, Product>());
            var productDto = Mapper.Map<ProductDTO, Product>(item);
            Uow.Products.Update(productDto);
            Uow.Save();
        }

        public void RemoveProduct(int id)
        {
            var product = Uow.Products.GetById(id);
            Uow.Products.Delete(product);
            Uow.Save();
        }

        public IEnumerable<ProductDTO> GetItemsPage(int page = 1)
        {
            var skip = page * 8;
            Mapper.Initialize(cfg => cfg.CreateMap<Product, UploadProductDTO>());
            var product = Uow.Products.GetAll().ToList().OrderBy(x=>x.Id).Skip(skip).Take(8);
            var productDto = Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(product);
           
            return productDto;
        }

        public IEnumerable GetProductsByName(string name)
        {
            IEnumerable<Product> products = Uow.Products.GetAll().Where(x => x.Name.StartsWith(name));
            var projection = from product in products
                select new 
                {
                    id = product.Id,
                    label = product.Name,
                    value = product.Name
                 
                };
            return projection.ToList();

        }

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}
