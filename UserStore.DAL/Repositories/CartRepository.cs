using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UserStore.DAL.Interfaces;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;

namespace UserStore.DAL.Repositories
{
   public class CartRepository:IRepository<Cart>
    {
        private ApplicationContext context;

        public CartRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IList<Cart> GetAll()
        {
            return context.Carts.ToList();
        }

        public Cart GetById(int id)
        {
            return context.Carts.Find(id);
        }

        public Cart Find(Func<Cart, bool> predicate)
        {
            return new Cart();
        }

        public void Create(Cart item)
        {
            context.Carts.Add(item);
        }

        public void Update(Cart item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Cart item)
        {
            context.Carts.Remove(item);
        }
    }
}
