using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UserStore.BLL.Interfaces;
using PizzaShopThreeLayer.Models;
using UserStore.BLL.DTO;
using UserStore.Models;
 

namespace UserStore.Controllers
{
    public class ProductController : AsyncController
    {
       
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
           
        }
        [HttpGet]
        public ActionResult UploadProduct()
        {
            return View("UploadProduct");
        }

        [HttpPost]
        public ActionResult UploadProduct(UploadProductViewModel prod, HttpPostedFileBase image)
        {
            if (ModelState.IsValid && image != null)
            {
                string path = Server.MapPath("~/Image/" + prod.Name.Replace(" ", "") + ".png");
                prod.Image = image;
                prod.Absolutepath = path;
                Mapper.Initialize(cfg =>cfg.CreateMap<UploadProductViewModel, UploadProductDTO>());

                var product = Mapper.Map<UploadProductViewModel, UploadProductDTO>(prod);
                _productService.CreateProduct(product);
                ModelState.AddModelError("", "Продукт успешно добавлен!");
            }
            else
            {
                ModelState.AddModelError("","Заполните все поля");
            }
               return View("UploadProduct");
        }
        

        [HttpGet]
        public ActionResult Remove(int ?ide)
        {
            if (!String.IsNullOrEmpty(ide.ToString()))
            {
                if (Request.IsAjaxRequest())
                {

                    _productService.RemoveProduct((int) ide);
                    return PartialView("Remove");

                }

                _productService.RemoveProduct((int)ide);
                IEnumerable<ProductDTO> prod = _productService.GetAll();
                Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
                var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(prod);
                return View("Products", products);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Edit(int? ide)
        {
            if (!string.IsNullOrEmpty(ide.ToString()))
            {
               var product = _productService.GetById((int) ide);
               Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, UploadProductViewModel>());
               var prod = Mapper.Map<ProductDTO, UploadProductViewModel>(product);
               return View("EditProduct",prod);
            }
            return HttpNotFound();
           
        }
        [HttpGet]
        public ActionResult Products()
        {
            IEnumerable<ProductDTO> prod = _productService.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(prod);

            return View("Products", products);
        }
        [HttpPost]
        public ActionResult Edit(UploadProductViewModel prod)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UploadProductViewModel, ProductDTO>());
                var product = Mapper.Map<UploadProductViewModel, ProductDTO>(prod);
                _productService.UpdateProduct(product);

                return RedirectToAction("Products");
            }

                return View("EditProduct", prod);
  
        }
        public ActionResult AutoComplete(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var pro = _productService.GetProductsByName(term);
                return Json(pro, JsonRequestBehavior.AllowGet); 
            }
            return RedirectToAction("Menu", "Home");
        }
        public ActionResult FoundProductByName(int? id)
        {
            if (id != null)
            {
                ProductDTO prod = _productService.GetById((int)id);
                Mapper.Initialize(x => x.CreateMap<ProductDTO, ProductViewModel>());
                var product = Mapper.Map<ProductDTO, ProductViewModel>(prod);

                return View(product);
            }
            return RedirectToAction("Menu", "Home");
        }

    }
}