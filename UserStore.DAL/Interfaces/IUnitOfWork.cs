using UserStore.DAL.Identity;
using System;
using System.Threading.Tasks;
using UserStore.DAL.Interfaces;
using UserStore.DAL.Entities;

namespace UserStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<Cart> Carts { get; }
        IRepository<Product> Products { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Order> Orders { get; }
        void Save();
        Task SaveAsync();
    }
}
