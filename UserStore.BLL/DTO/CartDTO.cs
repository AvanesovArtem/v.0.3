using System;
using UserStore.DAL.Entities;

namespace UserStore.BLL.DTO
{
   public class CartDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public decimal Price { get; set; }

        public string EmailUser { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
