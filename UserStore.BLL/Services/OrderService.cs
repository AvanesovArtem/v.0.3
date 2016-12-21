using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Interfaces;
using UserStore.DAL.Entities;

namespace UserStore.BLL.Services
{
   public class OrderService:IOrderService
    {
        private IUnitOfWork Uow { get; set; }
        public OrderService(IUnitOfWork db)
        {
            Uow = db;
        }
        public IEnumerable<OrderDTO> GetAll()
        {
            IList<OrderDTO> orderForView = new List<OrderDTO>();
            IEnumerable<Order> orderForEach = Uow.Orders.GetAll();
            foreach (var variable in orderForEach)
            {
                int prodAmount= 0;
                IEnumerable<Cart> carts =
                    Uow.Carts.GetAll().Where(x => x.EmailUser == variable.UserEmail && x.Product.BoughtFlag == true);
                foreach (var cartBuff in carts)
                {
                    prodAmount += cartBuff.Quantity;
                }
                orderForView.Add(new OrderDTO
                {
                     UserEmail = variable.UserEmail,
                     NumberOfHome = variable.NumberOfHome,
                     Housing = variable.Housing,
                     Street = variable.Street,
                     Name = variable.Name,
                     PhoneNumber = variable.PhoneNumber,
                     NumberOfFlat = variable.NumberOfFlat,
                     Access = variable.Access,
                     From = variable.From,
                     To = variable.To,
                     AmountOfProducts = prodAmount,
                     Products = carts
                });
            }

            return orderForView;
        }

       public void Create(UploadOrderDTO model,string userName)
        {
           var carts = Uow.Carts.GetAll().Where(x => x.EmailUser == userName && x.Product.BoughtFlag != true);

           foreach (var cart in carts)
           {
               cart.Product.BoughtFlag = true;
               Uow.Carts.Update(cart);
           }
           Mapper.Initialize(x => x.CreateMap<UploadOrderDTO, Order>());
           Order order = Mapper.Map<UploadOrderDTO, Order>(model);
           
            Uow.Orders.Create(order);
            Uow.Save();

        }

        public void RemoveAll(int userId)
        {
            var orders = Uow.Orders.GetAll();
            foreach (var variable in orders)
            {
                Uow.Orders.Delete(variable);
                Uow.Save();
            }

        }
    }
}
