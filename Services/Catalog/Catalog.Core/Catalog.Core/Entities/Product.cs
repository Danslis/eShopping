﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Product
{
    [BsonElement("Name")]
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public ProductBrand Brands { get; set; }
    public ProductType Types { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
}
