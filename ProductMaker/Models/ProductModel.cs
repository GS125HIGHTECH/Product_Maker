using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductMaker.Models
{
    public class ProductModel
    {
        [DisplayName("Id")]
        public required int Id { get; set; }
        [DisplayName("Product Name")]
        public required string Name { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Cost")]
        public required decimal Price { get; set; }
        [DisplayName("What you get...")]
        public required string Description { get; set; }
    }
}
