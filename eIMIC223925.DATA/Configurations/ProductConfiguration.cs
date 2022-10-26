using eIMIC223925.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eIMIC223925.DATA.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id); // khoá chính là Id
            builder.Property(x => x.Id).UseIdentityColumn(); // Set Id tự động tăng
            builder.Property(x => x.Price).IsRequired(); // Set Price là bắt buộc (not null)
            builder.Property(x => x.OriginalPrice).IsRequired();
            builder.Property(x => x.Stock).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.ViewCount).IsRequired().HasDefaultValue(0);
        }
    }
}
