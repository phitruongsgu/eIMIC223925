using eIMIC223925.ApiIntegration;
using eIMIC223925.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace eIMIC223925.WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISlideApiClient _slideApiClient;

		public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient)
		{
			_logger = logger;
			_slideApiClient = slideApiClient;
		}

		public async Task<IActionResult> Index()
		{
			var culture = CultureInfo.CurrentCulture.Name;
			var viewModel = new HomeViewModel
			{
				Slides = await _slideApiClient.GetAll()
			};

			return View(viewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
