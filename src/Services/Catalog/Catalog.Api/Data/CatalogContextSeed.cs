namespace Catalog.Api.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> products)
    {
        bool isProductExist = products.Find(x => true).Any();
        if (!isProductExist)
            products.InsertManyAsync(GetPreconfiguredProducts()).GetAwaiter().GetResult();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>
        {
            new Product
            {
                Id="602d2149e773f2a3990b47fs",
                Name="iPhone X",
                Summary="This phone is just plain awesome as at its time",
                Description="Lorem ipsum dolar sit amet, cosnectur adiptiscing elite",
                ImageFile="product-1.png",
                Price=950.00,
                Category="Smart Phone"
            },
            new Product
            {
                Id="602d2149e773f2a3990b47f6",
                Name="Samsung 10",
                Summary="This phone is just plain awesome as at its time",
                Description="Lorem ipsum dolar sit amet, cosnectur adiptiscing elite",
                ImageFile="product-2.png",
                Price=840.00,
                Category="Smart Phone"
            },
            new Product
            {
                Id="602d2149e773f2a3990b47f7",
                Name="Huawei Plus",
                Summary="This phone is just plain awesome as at its time",
                Description="Lorem ipsum dolar sit amet, cosnectur adiptiscing elite",
                ImageFile="product-3.png",
                Price=950.00,
                Category="White Appliance"
            },
            new Product
            {
                Id="602d2149e773f2a3990b47f8",
                Name="Xiaomi Mi 9",
                Summary="This phone is just plain awesome as at its time",
                Description="Lorem ipsum dolar sit amet, cosnectur adiptiscing elite",
                ImageFile="product-4.png",
                Price=950.00,
                Category="Smart Phone"
            },
            new Product
            {
                Id="602d2149e773f2a3990b47f9",
                Name="Nokia Xtra",
                Summary="This phone is just plain awesome as at its time",
                Description="Lorem ipsum dolar sit amet, cosnectur adiptiscing elite",
                ImageFile="product-5.png",
                Price=950.00,
                Category="Smart Phone"
            }
        };
    }
}
