using eIMIC223925.ViewModels.Catalog.ProductImages;
using eIMIC223925.ViewModels.Catalog.Products;
using eIMIC223925.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eIMIC223925.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<ProductVm> GetById(int productId, string languageId);
        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewcount(int productId);
        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
        Task<List<ProductVm>> GetAll();// string languageId);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
    }
}
