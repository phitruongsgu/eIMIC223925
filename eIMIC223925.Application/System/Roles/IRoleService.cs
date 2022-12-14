using eIMIC223925.ViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eIMIC223925.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}
