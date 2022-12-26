﻿using eIMIC223925.Application.Catalog.Slides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eIMIC223925.BackendAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class SlidesController : ControllerBase
	{
		private readonly ISlideService _slideService;

		public SlidesController(ISlideService slideService)
		{
			_slideService = slideService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetAll()
		{
			var slides = await _slideService.GetAll();
			return Ok(slides);
		}
	}
}
