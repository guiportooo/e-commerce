namespace ECommerce.Api.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public bool Available => Quantity > 0;

        public Product(int id, string name, decimal price, string description, Category category, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Quantity = quantity;
        }
    }
}
