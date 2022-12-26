using eIMIC223925.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eIMIC223925.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<CategoryVm> GetById(string languageId, int id);

        Task<int> Create(CategoryCreateRequest request);

        Task<int> Delete(int categoryId);

        Task<int> Update(CategoryUpdateRequest request);
    }
}
