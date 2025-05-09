namespace CoffeeBeansDemo.Domain.Models
{
    public record SearchParams
    {
        public string Id { get; set; } = string.Empty;
        public int? Index { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Colour { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Cost { get; set; } = string.Empty;
        public bool? IsBOTD { get; set; }
    }
}
