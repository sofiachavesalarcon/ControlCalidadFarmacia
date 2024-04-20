using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlCalidadFarmacia.Model
{
    public class Tests
    {
        [Key]
        public int TestId { get; set; }
        public required int ProductId { get; set; }
        public required int LaboratoryId { get; set; }
        public required int TypeId { get; set; }
        public required string Observations { get; set; }
        public required DateTime DateTest { get; set; }
        

        /// relations




    }
}
