
namespace Makete.Webshop.Domain.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }


        public Brand(int id, string name)
        {
            BrandId = id;
            BrandName = name;
        }
       
        public Brand() { }
    }
}
