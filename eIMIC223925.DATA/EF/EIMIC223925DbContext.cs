using eIMIC223925.DATA.Configurations;
using Microsoft.EntityFrameworkCore;

namespace eIMIC223925.DATA.EF
{
    public class EIMIC223925DbContext : DbContext
    {
        public EIMIC223925DbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // apply những cấu hình thuộc tính của Entity (ví dụ ràng buộc, khoá chính, khoá ngoại,...)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

    }
}
