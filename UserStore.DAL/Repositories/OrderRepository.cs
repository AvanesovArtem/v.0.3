using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UserStore.DAL.Interfaces;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;

namespace UserStore.DAL.Repositories
{
    class OrderRepository:IRepository<Order>
    {

        private ApplicationContext context;


        public OrderRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IList<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return context.Orders.Find(id);
        }

        public Order Find(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Order item)
        {
            context.Orders.Add(item);
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
