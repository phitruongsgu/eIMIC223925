﻿namespace eIMIC223925.DATA.Entities
{
    public class ProductInCategory
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
