using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PizzaShopThreeLayer.Models;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Entities;
using UserStore.Models;

namespace UserStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _serv;
        public OrderController(IOrderService serv)
        {
            _serv = serv;
        }

        public ActionResult MakeOrder(UploadOrderViewModel model)
        {
            Mapper.Initialize(x=>x.CreateMap<UploadOrderViewModel,UploadOrderDTO>());
            var order = Mapper.Map<UploadOrderViewModel, UploadOrderDTO>(model);

           _serv.Create(order,User.Identity.Name);
            return PartialView();
        }
        public ActionResult Orders()
        {
            Mapper.Initialize(x => x.CreateMap<OrderDTO,OrderViewModel>());
             var orders = _serv.GetAll();
       
            var order = Mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(orders);
            return View("AllOrders",orders);
        }

    }
}