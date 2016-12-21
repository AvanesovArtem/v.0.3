using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;
using UserStore.DAL.Interfaces;

namespace UserStore.DAL.Repositories
{
    class BackgrImgRepository
    {
        
        private ApplicationContext context;

        public BackgrImgRepository(ApplicationContext context)
        {
            this.context = context;
        }
        //public IList<BackgroundImage> GetAll()
        //{
        //    return context.BackgroundImages.ToList();
        //}

        //public BackgroundImage GetById(int id)
        //{
        //    return context.BackgroundImages.Find(id);
        //}

        //public BackgroundImage Find(Func<BackgroundImage, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Create(BackgroundImage item)
        //{
        //    context.BackgroundImages.Add(item);
        //}

        //public void Update(BackgroundImage item)
        //{
        //    context.Entry(item).State = EntityState.Modified;
        //}

        //public void Delete(BackgroundImage item)
        //{
        //    context.BackgroundImages.Remove(item);
        //}
    }
}
