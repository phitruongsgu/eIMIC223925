using eIMIC223925.ApiIntegration;
using eIMIC223925.Utilities.Constants;
using eIMIC223925.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace eIMIC223925.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        //private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient,
            IConfiguration configuration
            //,ICategoryApiClient categoryApiClient
            )
        {
            _configuration = configuration;
            _productApiClient = productApiClient;
            //_categoryApiClient = categoryApiClient;
        }
        public async Task<IActionResult> Index(string keyWord, int? categoryId, int pageIndex = 1, int pageSize = 5)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
                CategoryId = categoryId
            };

            var data = await _productApiClient.GetPagings(request);



            return View(data);
        }


    }
}
