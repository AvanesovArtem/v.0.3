using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.DAL.Entities;

namespace UserStore.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<BackgroundImage> BackgroundImages { get; set; }
    }
}
