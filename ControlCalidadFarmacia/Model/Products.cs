using System.ComponentModel.DataAnnotations;

namespace ControlCalidadFarmacia.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public required string ProductName { get; set;}
        public required string ProductDescription { get; set;}

        public required DateTime ProductManufacturingDate { get; set;}
        public required DateTime ProductExpirationDate { get; set;}
       
    }
}
