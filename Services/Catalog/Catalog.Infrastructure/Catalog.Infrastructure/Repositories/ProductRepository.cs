using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository, IBrandRepository, ITypesRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context
          .Products
          .Find(p => true)
          .ToListAsync();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _context
           .Products
           .Find(p => p.Id == id)
           .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProducntByName(string name)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
        return await _context
            .Products
            .Find(filter)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProducntByBrand(string brand)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Brands.Name, brand);
        return await _context
            .Products
            .Find(filter)
            .ToListAsync();
    }

    public async Task<Product> CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
        return product;
    }

    public Task<Product> DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductBrand>> GetBrandsAsync()
    {
        throw new NotImplementedException();
    }    

    public Task<IEnumerable<ProductType>> GetProductTypesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
