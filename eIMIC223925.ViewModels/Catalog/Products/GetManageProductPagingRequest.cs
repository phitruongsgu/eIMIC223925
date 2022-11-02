using eIMIC223925.ViewModels.Common;
using System.Collections.Generic;

namespace eIMIC223925.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
