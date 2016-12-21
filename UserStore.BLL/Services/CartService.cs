using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Interfaces;
using UserStore.DAL.Repositories;
using UserStore.BLL.DTO;
using UserStore.DAL.Entities;

namespace UserStore.BLL.Services
{
   public class CartService:ICartService
    {
        private IUnitOfWork Uow { get; set; }
        public CartService(UnitOfWork db)
        {
            Uow = db;
        }

        public CartDTO GetById(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Cart, CartDTO>());
            var cart = Uow.Carts.GetById(id);
            var commentDto = Mapper.Map<Cart, CartDTO>(cart);
            return commentDto;
        }

       public IEnumerable<CartDTO> GetAllUserProduct(string userEmail)
       {
           var carts = Uow.Carts.GetAll().Where(x => x.EmailUser == userEmail && x.Product.BoughtFlag != true);
        
           Mapper.Initialize(x=>x.CreateMap<Cart,CartDTO>());
           var cartsDto = Mapper.Map<IEnumerable<Cart>,IEnumerable<CartDTO>>(carts);
           return cartsDto;
       }

       public void AddToCart(int productId,string userId)
       {
           var _cart = Uow.Carts.GetAll().Where(x=>x.EmailUser == userId).FirstOrDefault(x => x.ProductId == productId);
           var product = Uow.Products.GetById(productId);
           if (_cart == null)
           {
               Cart cart = new Cart
               {
                   ProductId = productId,
                   EmailUser = userId,
                   Quantity = 1,
                   Price = product.Price
               };
               Uow.Carts.Create(cart);
               Uow.Save();
           }
           else
           {
               _cart.Quantity ++;
               _cart.Price += product.Price;
               Uow.Carts.Update(_cart);
               Uow.Save();
           }
       }

       public void UpdateQuantity(int id,int quantity)
        {
            var boughtProduct = Uow.Carts.GetById(id);
                boughtProduct.Quantity = quantity;
            Uow.Carts.Update(boughtProduct);
            Uow.Save();

        }

       public void RemoveAllByUser(string userId)
       {
            var carts = Uow.Carts.GetAll().Where(x => x.EmailUser == userId);
            foreach (var cart in carts)
            {
                Uow.Carts.Delete(cart);
                Uow.Save();
            }
        }


       public void RemoveProductFromCart(int id)
        {
            var cart = Uow.Carts.GetAll().FirstOrDefault(x => x.Id == id);
            Uow.Carts.Delete(cart);
            Uow.Save();
        }

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}
