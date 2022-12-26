using eIMIC223925.ApiIntegration;
using eIMIC223925.Utilities.Constants;
using eIMIC223925.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eIMIC223925.AdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryController(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var categories = await _categoryApiClient.GetAll(languageId);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _categoryApiClient.CreateCategory(request);
            if (result)
            {
                TempData["result"] = "Thêm mới loại sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới loại sản phẩm thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // thêm ngôn ngữ để nó có khi chạy vào GetById ở dưới
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var result = await _categoryApiClient.GetById(languageId, id);

            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new CategoryDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _categoryApiClient.DeleteCategory(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa thể loại thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var category = await _categoryApiClient.GetById(languageId, id);
            var editVm = new CategoryUpdateRequest()
            {
                Id = category.Id,
                Name = category.Name,
                SeoAlias = category.SeoAlias,
                SeoDescription = category.SeoDescription,
                SeoTitle = category.SeoTitle
            };
            return View(editVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _categoryApiClient.UpdateCategory(request);
            if (result)
            {
                TempData["result"] = "Cập nhật thể loại thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thể loại thất bại");
            return View(request);
        }
    }
}
