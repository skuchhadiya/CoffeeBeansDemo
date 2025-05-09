using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeBeansDemo.Persistence.Entities
{
    public record CoffeeBean
    {
        protected Guid id = Guid.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get
            {
                return this.id != Guid.Empty ? this.id : Guid.NewGuid();
            }
            set
            {
                this.id = value;
            }
        }

        public int Index { set; get; }

        public bool IsBOTD { set; get; }

        public string Cost { set; get; } = string.Empty;

        public string Image { set; get; } = string.Empty;

        public string Colour { set; get; } = string.Empty;

        public string Name { set; get; } = string.Empty;

        public string Description { set; get; } = string.Empty;

        public string Country { set; get; } = string.Empty;
    }
}
