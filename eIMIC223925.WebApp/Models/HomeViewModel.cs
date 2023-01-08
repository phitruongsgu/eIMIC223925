using eIMIC223925.ViewModels.Catalog.Products;
using eIMIC223925.ViewModels.Catalog.Slides;
using System.Collections.Generic;

namespace eIMIC223925.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVm> Slides { get; set; }
        public List<ProductVm> FeaturedProducts { get; set; }
        public List<ProductVm> LatestProducts { get; set; }

    }
}
