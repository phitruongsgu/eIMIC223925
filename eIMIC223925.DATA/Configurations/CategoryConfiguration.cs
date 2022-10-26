using eIMIC223925.DATA.Entities;
using eIMIC223925.DATA.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eIMIC223925.DATA.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories"); // đặt tên bảng ở trong SQL Server
            builder.HasKey(x => x.Id); // khoá chính là Id
            builder.Property(x => x.Id).UseIdentityColumn(); // Set Id tự động tăng
            builder.Property(x => x.Status).HasDefaultValue(Status.Active); // Set cột Status có giá trị mặc định là Active trong enum Status 
        }
    }
}
