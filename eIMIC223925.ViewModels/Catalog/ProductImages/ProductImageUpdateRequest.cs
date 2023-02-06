using Microsoft.AspNetCore.Http;

namespace eIMIC223925.ViewModels.Catalog.ProductImages
{
    public class ProductImageUpdateRequest
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string Name { set; get; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public string ThumbnailImage { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
