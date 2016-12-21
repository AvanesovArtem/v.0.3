namespace UserStore.DAL.Entities
{
    public class Cart
    {
        
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string EmailUser { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}