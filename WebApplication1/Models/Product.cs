﻿using AspNetCoreEgitim6584.Models;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public virtual Category? Category{ get; set; }
}
}
