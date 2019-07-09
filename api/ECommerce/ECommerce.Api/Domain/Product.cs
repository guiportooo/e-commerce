namespace ECommerce.Api.Domain
{
    public class Product
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public string Description { get; protected set; }
        public Category Category { get; protected set; }
        public int Quantity { get; protected set; }
        public bool Available => Quantity > 0;

        public Product(string name, decimal price, string description, Category category, int quantity)
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Quantity = quantity;
        }

        public Product(int id, string name, decimal price, string description, Category category, int quantity)
            : this(name, price, description, category, quantity)
            => Id = id;
    }
}
