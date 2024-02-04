using desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace desafio.Data.Map
{
    public class VehicleMap : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Type).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Brand).HasMaxLength(255);
            builder.Property(x => x.Color).HasMaxLength(255);
        }
    }
}
