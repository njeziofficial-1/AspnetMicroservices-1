﻿using System.Linq.Expressions;

namespace Catalog.Api.Repositories;

public class ProductRepository : IProductRepository
{
    readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task CreateProduct(Product product)
    => await _context.Products.InsertOneAsync(product);

    public async Task<bool> DeleteProduct(string id)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Id, id);
        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
    public async Task<IEnumerable<Product>> GetProducts()
    => await _context
        .Products
        .Find(p => true)
        .ToListAsync();

    public async Task<Product> GetProduct(string id)
    => await _context
        .Products
        .Find(x => x.Id == id)
        .FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Name, name);
        return await FilterRequest(filter);
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string category)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Category, category);
        return await FilterRequest(filter);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = await _context
            .Products
            .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    private async Task<IEnumerable<Product>> FilterRequest(FilterDefinition<Product> filter)
    => await _context
            .Products
            .Find(filter)
            .ToListAsync();
    private async Task<IEnumerable<Product>> FilterRequest(Expression<Func<Product, bool>> filter)
    => await _context
        .Products
        .Find(filter)
        .ToListAsync();
}
