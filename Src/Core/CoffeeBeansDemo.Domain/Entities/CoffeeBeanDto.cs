using CoffeeBeansDemo.Persistence.Entities;
using System.Text.Json.Serialization;

namespace CoffeeBeansDemo.Domain.Entities
{
    public record CoffeeBeanDto : CoffeeBean
    {
        public CoffeeBeanDto(CoffeeBean coffeeBean)
        {
            this.Id = coffeeBean.Id;
            this.Index= coffeeBean.Index;

            this.IsBOTD = coffeeBean.IsBOTD;

            this. Cost = coffeeBean.Cost;

            this.Image = coffeeBean.Image;

            this.Colour = coffeeBean.Colour;

            this.Name = coffeeBean.Name;
        
            this.Description = coffeeBean.Description;

            this.Country = coffeeBean.Country;

        }
    }
}
