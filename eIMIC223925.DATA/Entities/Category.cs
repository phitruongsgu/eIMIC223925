using eIMIC223925.DATA.Enum;
using System.Collections.Generic;

namespace eIMIC223925.DATA.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int SortOrder { get; set; } // cho lưu thay đổi dữ liệu
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
