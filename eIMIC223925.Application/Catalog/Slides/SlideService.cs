using eIMIC223925.DATA.EF;
using eIMIC223925.ViewModels.Catalog.Slides;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eIMIC223925.Application.Catalog.Slides
{
	public class SlideService : ISlideService
	{
		private readonly EIMIC223925DbContext _context;

		public SlideService(EIMIC223925DbContext context)
		{
			_context = context;
		}

		public async Task<List<SlideVm>> GetAll()
		{
			var slides = await _context.Slides.OrderBy(x => x.SortOrder)
				.Select(x => new SlideVm()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Url = x.Url,
					Image = x.Image
				}).ToListAsync();

			return slides;
		}
	}
}
