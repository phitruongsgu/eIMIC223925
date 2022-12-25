using System.ComponentModel.DataAnnotations;

namespace eIMIC223925.ViewModels.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        public int SortOrder { get; set; } // cho lưu thay đổi dữ liệu
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên loại sản phẩm")]
        public string Name { get; set; }

        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string LanguageId { get; set; }
        public string SeoAlias { get; set; }
    }
}
