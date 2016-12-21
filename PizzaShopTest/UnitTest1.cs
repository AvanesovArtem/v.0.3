using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserStore.BLL.Interfaces;
using UserStore.Controllers;
using UserStore.BLL.Services;
using UserStore.DAL.Interfaces;
using UserStore.DAL.Repositories;
using UserStore.Models;

namespace PizzaShopTest
{
    [TestClass]
    public class ProductControllerTest
    {
        private ProductController controller;
        private IProductService productService;


        
        [TestInitialize]
        public void Initialize()
        {
         
        }
        [TestMethod]
        public void CheckProductsTest()
        {
           ViewResult result =  controller.Products() as ViewResult;

            ICollection<ProductViewModel> prod = (ICollection<ProductViewModel>) result.Model;

            ProductViewModel product = prod.FirstOrDefault();

            Assert.IsNotNull(product);
        }
    }
}
