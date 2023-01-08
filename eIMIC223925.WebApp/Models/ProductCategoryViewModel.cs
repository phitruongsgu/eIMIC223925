using eIMIC223925.ViewModels.Catalog.Categories;
using eIMIC223925.ViewModels.Catalog.Products;
using eIMIC223925.ViewModels.Common;

namespace eIMIC223925.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVm> Products { get; set; }
    }
}
