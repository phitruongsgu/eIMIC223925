using eIMIC223925.DATA.EF;
using eIMIC223925.ViewModels.Common;
using eIMIC223925.ViewModels.System.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eIMIC223925.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _config;
        private readonly EIMIC223925DbContext _context;

        public LanguageService(EIMIC223925DbContext context,
            IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name,
                IsDefault = x.IsDefault
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}
