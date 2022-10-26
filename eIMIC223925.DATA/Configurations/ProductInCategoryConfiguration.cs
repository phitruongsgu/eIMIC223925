using eIMIC223925.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eIMIC223925.DATA.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories"); // đặt tên bảng ở SQL Server
            builder.HasKey(x => new { x.CategoryId, x.ProductId }); // thiết lập 2 khoá chính
            builder.HasOne(x => x.Category).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.CategoryId); // thiết lập khoá ngoại trong Entity Category
            builder.HasOne(x => x.Product).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.ProductId); // thiết lập khoá ngoại trong Entity Product
        }
    }
}
