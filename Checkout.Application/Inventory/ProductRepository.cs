using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Checkout.Inventory
{
    using Models;
    using Interfaces;
    using Location;

    public class ProductRepository : IProductRepository, ITransientService
    {
        private readonly IEnumerable<ProductEntity> items;

        public ProductRepository(ICountryRepository countryRepository)
        {
            // TOD: replace with valid data repo
            items = new List<ProductEntity>
            {
                Create(1, "Pencil", "100101", 1.99M, 1),
                Create(1, "Pen", "100102", 2.99M, 1),
                Create(1, "A4 Paper (50 pack)", "100103", 9.99M, 1),
                Create(1, "A5 Paper (50 pack)", "100104", 8.99M, 1),
                Create(1, "Notepad", "100105", 4.99M, 1),
                Create(1, "Mouse", "100106", 7.99M, 1),
                Create(1, "Keyboard", "100107", 11.99M, 1),
                Create(1, "LCD Monitor", "100108", 129.99M, 1),
            };
        }


        public IEnumerable<ProductEntity> Get(bool? isActive)
        {
            // TODO: replace with valid repo call
            return items.Where(w => isActive == null || w.IsActive == (bool)isActive);
        }

        public ProductEntity Get(int id)
        {
            return items.FirstOrDefault(f => f.Id == id);
        }

        // temp product entity crestor
        ProductEntity Create(int id, string name, string code, decimal netPrice, short countryId)
        {
            return new ProductEntity
            {
                Id = id,
                Name = name,
                Code = code,
                CountryId = countryId,
                NetPrice = netPrice,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                IsActive = true
            };
        }

    }
}
