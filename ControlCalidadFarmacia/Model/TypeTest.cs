using System.ComponentModel.DataAnnotations;

namespace ControlCalidadFarmacia.Model
{
    public class TypeTest
    {
        [Key]
        public int  TypeId { get; set; }
        public required string TypeName { get; set; }
        
    }
}
