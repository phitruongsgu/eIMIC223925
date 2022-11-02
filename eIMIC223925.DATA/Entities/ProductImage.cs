using System;

namespace eIMIC223925.DATA.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; } // sắp xếp thứ tự các hình

        public long FileSize { get; set; }

        public Product Product { get; set; }
    }
}
