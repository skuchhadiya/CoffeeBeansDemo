namespace CoffeeBeansDemo.Domain.Models
{
    public record CoffeeBeanEditDto
    {
        public string Id { set; get; }

        public string IsBOTD { set; get; }

        public string Cost { set; get; } = string.Empty;

        public string Image { set; get; } = string.Empty;

        public string Colour { set; get; } = string.Empty;

        public string Name { set; get; } = string.Empty;

        public string Description { set; get; } = string.Empty;

        public string Country { set; get; } = string.Empty;
    }
}
