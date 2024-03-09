﻿namespace shopping.Application.Models.Category
{
    public class CategoryGetModel
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
