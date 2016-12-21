using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Services;

namespace UserStore.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<ICartService>().To<CartService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IOrderService>().To<OrderService>();

        }
    }
}