using CSharp_MongoDB.App;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

const string CONNECTION_STRING = "mongodb://localhost:27017";
var client = new MongoClient(CONNECTION_STRING);

var db = client.GetDatabase("products_db");
var collection = db.GetCollection<BsonDocument>("products");
var products = collection
    .FindSync(new BsonDocument())
    .ToList()
    .Select(doc => BsonSerializer.Deserialize<Product>(doc))
    .ToList();

var res = from product in products
    where product.Price > 2
    select (product.Name, product.Price);

foreach (var (name, price) in res)
{
    Console.WriteLine($"{name} -> {price}");
}
