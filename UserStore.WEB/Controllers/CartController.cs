using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Services;
using UserStore.DAL.Repositories;
using UserStore.BLL.DTO;
using UserStore.Models;

namespace UserStore.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        public CartController()
        {
            _cartService = new CartService(new UnitOfWork("DefaultConnection"));
        }
        // GET: Cart
        public ActionResult AddedProducts()
        {
            IEnumerable<CartDTO> prod = _cartService.GetAllUserProduct(User.Identity.Name);
            Mapper.Initialize(cfg => cfg.CreateMap<CartDTO, CartViewModel>());
            var products = Mapper.Map<IEnumerable<CartDTO>, List<CartViewModel>>(prod);
            return View("Products",products);
        }
        public ActionResult Remove(int ?ide)
        {
            if (ide != null)
            {
                _cartService.RemoveProductFromCart((int)ide);
                return PartialView("Remove");
            }
            return RedirectToAction("AddedProducts");

        }
        public ActionResult AddToCart(int? ide)
        {
            if (ide != null)
            {
                _cartService.AddToCart((int)ide, User.Identity.Name);
                return PartialView("AddedProductToCartPartial");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}