using System.Collections.Generic;
using UserStore.DAL.Entities;

namespace UserStore.BLL.DTO
{
   public class OrderDTO
    {
        public int Id { get; set; }
        public IEnumerable<Cart> Products { get; set; }
        public string UserEmail { get; set; }
        public int NumberOfHome { get; set; }
        public int Housing { get; set; }
        public string Street { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int NumberOfFlat { get; set; }
        public int Access { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int AmountOfProducts { get; set; }
    }
}
