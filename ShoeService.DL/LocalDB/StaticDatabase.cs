using ShoeService.Models.Entities;
using System.Collections.Generic;

namespace ShoeService.DL.LocalDb
{
    public static class StaticDatabase
    {
        public static List<Shoe> Shoes { get; set; } = new List<Shoe>()
        {
            new Shoe
            {
                Id = Guid.NewGuid().ToString(),
                Brand = "Nike",
                Model = "Air Max",
                Size = 42.5,
                Price = 199,
                Quantity = 10,
                Category = "Sport"
            },
            new Shoe
            {
                Id = Guid.NewGuid().ToString(),
                Brand = "Adidas",
                Model = "Ultraboost",
                Size = 44,
                Price = 220,
                Quantity = 5,
                Category = "Running"
            }
        };

        public static List<Customer> Customers { get; set; } = new List<Customer>()
        {
            new Customer
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Ivan Petrov",
                Email = "ivan@example.com"
            }
        };
    }
}
