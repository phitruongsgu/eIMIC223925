using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace eIMIC223925.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal Price { set; get; } // Product
        public decimal OriginalPrice { set; get; } // Product
        public int Stock { set; get; } // Product

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { set; get; } // ProductTranslation

        public string Description { set; get; } // ProductTranslation
        public string Details { set; get; } // ProductTranslation
        public string SeoDescription { set; get; } // ProductTranslation
        public string SeoTitle { set; get; } // ProductTranslation

        public string SeoAlias { get; set; } // ProductTranslation
        public string LanguageId { set; get; } // ProductTranslation
        public IFormFile ThumbnailImage { get; set; }
    }
}
