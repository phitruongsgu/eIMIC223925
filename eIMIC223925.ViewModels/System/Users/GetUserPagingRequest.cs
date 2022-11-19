using eIMIC223925.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eIMIC223925.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}