using eIMIC223925.ViewModels.Catalog.ProductImages;
using eIMIC223925.ViewModels.Catalog.Products;
using eIMIC223925.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eIMIC223925.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<bool> UpdateProduct(ProductUpdateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<ProductVm> GetById(int id, string languageId);

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

        Task<bool> DeleteProduct(int id);

        Task<ProductImageViewModel> GetImageById(int productId, int imageId);

        Task<bool> UpdatePrice(int id, decimal newPrice);

        Task<bool> UpdateStock(int id, int addedQuantity);
    }
}
