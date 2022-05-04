namespace DDD.Product.IntegrationEvents.Events.Model
{
    public class ProductDto
    {
        public ProductDto(Guid id, string title, double price, string color, string type)
        {
            Id = id;
            Title = title;
            Price = price;
            Color = color;
            Type = type;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
    }
}