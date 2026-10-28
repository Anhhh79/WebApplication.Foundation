using Foundation.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foundation.Api.Data.Configurations
{
    public class SampleItemConfiguration : IEntityTypeConfiguration<SampleItem>
    {
        public void Configure(EntityTypeBuilder<SampleItem> builder)
        {
            builder.ToTable<SampleItem>("SampleItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
