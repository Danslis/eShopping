using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class TypeContextSeed
{
    public static void SeedData(IMongoCollection<ProductType> typeCollection)
    {
        bool checkTypes = typeCollection.Find(b => true).Any();
        string path = Directory.GetCurrentDirectory();
        //string path = Path.Combine("Data", "SeedData", "types.json");
        if (!checkTypes)
        {
            var typesData = File.ReadAllText("../Catalog/Catalog.Infrastructure/Catalog.Infrastructure/Data/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            if (types != null)
            {
                foreach (var item in types)
                {
                    typeCollection.InsertOneAsync(item);
                }
            }
        }
    }
}