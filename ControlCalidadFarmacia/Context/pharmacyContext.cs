using ControlCalidadFarmacia.Model;
using Microsoft.EntityFrameworkCore;

namespace ControlCalidadFarmacia.Context

{
    public class pharmacyContext: DbContext
    {
        public pharmacyContext(DbContextOptions<pharmacyContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        // Add Model to context
        public DbSet<Products> products { get; set; }
        public DbSet<Tests> tests { get; set; }
        public DbSet<Laboratory> laboratorys { get; set; }
        public DbSet<TypeTest> typeTests { get; set; }



    }
}
