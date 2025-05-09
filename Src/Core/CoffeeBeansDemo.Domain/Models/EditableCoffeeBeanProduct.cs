namespace CoffeeBeansDemo.Domain.Models
{
    public record EditableCoffeeBeanProduct
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Colour { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Cost { get; set; } = string.Empty;
        public bool isBOTD { get; set; } = false;

    }
}
