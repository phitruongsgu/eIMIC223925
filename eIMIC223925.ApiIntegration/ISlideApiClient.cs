using eIMIC223925.ViewModels.Catalog.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eIMIC223925.ApiIntegration
{
	public interface ISlideApiClient
	{
		Task<List<SlideVm>> GetAll();
	}
}
