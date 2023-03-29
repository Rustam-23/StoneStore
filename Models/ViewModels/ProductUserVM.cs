﻿using System.Collections.Generic;

namespace StoneStore.Models.ViewModels
{
    public class ProductUserVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Product> ProductList { get; set; }


        public ProductUserVM()
        {
            ProductList = new List<Product>();
        }
    }
}