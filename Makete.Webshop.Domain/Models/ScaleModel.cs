using System.ComponentModel;

namespace Makete.Webshop.Domain.Models
{
    public class ScaleModel
    {
        public int Id { get; set; }

        [DisplayName("Naziv")]
        public string Name { get; set; }

        [DisplayName("Proizvođač")]
        public Brand ItemBrand { get; set; }

        [DisplayName("Kategorija")]
        public string? Category { get; set; }

        [DisplayName("Mjerilo")]
        public string Scale { get; set; }

        [DisplayName("Dostupna količina")]
        public int AmountAvailable { get; set; }

        [DisplayName("Cijena")]
        public double Price { get; set; }

    }
}
