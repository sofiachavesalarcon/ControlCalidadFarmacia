using System.ComponentModel.DataAnnotations;

namespace ControlCalidadFarmacia.Model
{
    public class Laboratory
    {
        [Key]
        public int LaboratoryId { get; set; }
        public required string  LaboratoryName { get; set;}

        public required string Addres { get; set;}

        public required string Email { get; set;}
        
    }
}
