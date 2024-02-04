using desafio.Models;
using desafio.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace desafio.Data
{
    public class DesafioDBContext : DbContext
    {
        public DesafioDBContext(DbContextOptions<DesafioDBContext> options): base(options) { }

        public DbSet<VehicleModel> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
