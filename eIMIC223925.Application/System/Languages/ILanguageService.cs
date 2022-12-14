using eIMIC223925.ViewModels.Common;
using eIMIC223925.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eIMIC223925.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}
