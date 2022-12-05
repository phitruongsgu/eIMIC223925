using eIMIC223925.ViewModels.Common;
using eIMIC223925.ViewModels.System.Users;
using System.Threading.Tasks;

namespace eIMIC223925.ApiIntegration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
    }
}
