using eIMIC223925.DATA.EF;
using eIMIC223925.DATA.Entities;
using eIMIC223925.DATA.Enum;
using eIMIC223925.Utilities.Constants;
using eIMIC223925.Utilities.Exceptions;
using eIMIC223925.ViewModels.Catalog.Categories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eIMIC223925.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EIMIC223925DbContext _context;

        public CategoryService(EIMIC223925DbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(m => new CategoryVm()
            {
                Id = m.c.Id,
                Name = m.ct.Name,
                ParentId = m.c.ParentId
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
                SeoDescription = x.ct.SeoDescription, // thêm vào
                SeoTitle = x.ct.SeoTitle,
                LanguageId = x.ct.LanguageId,
                SeoAlias = x.ct.SeoAlias
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<CategoryTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = request.Name,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    });
                }
                else
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = SystemConstants.ProductConstants.NA,
                        SeoAlias = SystemConstants.ProductConstants.NA,
                        LanguageId = language.Id
                    });
                }
            }
            var category = new Category()
            {
                SortOrder = request.SortOrder,
                IsShowOnHome = request.IsShowOnHome,
                ParentId = request.ParentId,
                Status = Status.InActive,
                CategoryTranslations = translations
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> Delete(int categoryId)
        {
            //Tìm category cần xóa
            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                throw new eIMIC223925Exception($"Cannot find a category: {categoryId}");
            }


            _context.Categories.Remove(category);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(CategoryUpdateRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);
            var categoryTranslations = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.Id
            && x.LanguageId == request.LanguageId);

            if (category == null || categoryTranslations == null)
            {
                throw new eIMIC223925Exception($"Cannot find a category with id: {request.Id}");
            }

            categoryTranslations.Name = request.Name;
            categoryTranslations.SeoAlias = request.SeoAlias;
            categoryTranslations.SeoDescription = request.SeoDescription;
            categoryTranslations.SeoTitle = request.SeoTitle;

            return await _context.SaveChangesAsync();
        }
    }
}
