using eIMIC223925.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace eIMIC223925.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
