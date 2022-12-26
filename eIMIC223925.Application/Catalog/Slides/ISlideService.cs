using eIMIC223925.ViewModels.Catalog.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eIMIC223925.Application.Catalog.Slides
{
	public interface ISlideService
	{
		Task<List<SlideVm>> GetAll();
	}
}
