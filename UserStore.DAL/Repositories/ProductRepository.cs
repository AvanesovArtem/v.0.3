using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UserStore.DAL.Interfaces;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;

namespace UserStore.DAL.Repositories
{
    internal class ProductRepository : IRepository<Product>
    {
        private ApplicationContext context;


        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IList<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

       

        public void Create(Product item)
        {
            context.Products.Add(item);
        }

        public void Update(Product item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Product item)
        {
            context.Products.Remove(item);

        }

        Product Find(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        Product IRepository<Product>.Find(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
