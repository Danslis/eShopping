﻿using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProducntByName(string name);
    Task<IEnumerable<Product>> GetProducntByBrand(string brand);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<Product> DeleteProduct(string id);
}