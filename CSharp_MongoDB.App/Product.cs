using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSharp_MongoDB.App;

public class Info
{
    [BsonElement("measure")] public string? Measure { get; set; }

    [BsonElement("amount")] public double? Amount { get; set; }
}

public class Product
{
    public ObjectId Id { get; set; }

    [BsonElement("product_name")] public string? Name { get; set; }

    [BsonElement("price")] public double? Price { get; set; }

    [BsonElement("info")] public Info? Info { get; set; }
}
