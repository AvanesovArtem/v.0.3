using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UserStore.DAL.Interfaces;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;

namespace UserStore.DAL.Repositories
{
    class CommentRepository:IRepository<Comment>
    {
        private ApplicationContext context;

        public CommentRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IList<Comment> GetAll()
        {
            return context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return context.Comments.Find(id);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Comment item)
        {
            context.Comments.Add(item);
        }

        public void Update(Comment item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Comment item)
        {
            context.Comments.Remove(item);
        }

        Comment IRepository<Comment>.Find(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
