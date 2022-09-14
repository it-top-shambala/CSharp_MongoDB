using CSharp_MongoDB.App;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

const string CONNECTION_STRING = "mongodb://localhost:27017";
var client = new MongoClient(CONNECTION_STRING);

var db = client.GetDatabase("products_db");
var collection = db.GetCollection<BsonDocument>("products");
var products = collection.FindSync(new BsonDocument()).ToList();
foreach (var document in products)
{
    var product = BsonSerializer.Deserialize<Product>(document);
    Console.WriteLine($"{product.Name}: {product.Info?.Amount}");
}
