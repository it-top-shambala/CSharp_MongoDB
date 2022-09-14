using CSharp_MongoDB.App;
using MongoDB.Bson;
using MongoDB.Driver;

const string CONNECTION_STRING = "mongodb://localhost:27017";
var client = new MongoClient(CONNECTION_STRING);

var db = client.GetDatabase("products_db");
var collection = db.GetCollection<Product>("products");
var product = new Product()
{
    Name = "Pro",
    Price = 5.0,
    Info = new Info()
    {
        Measure = "unit",
        Amount = 0
    }
};

collection.InsertOne(product);

var products = collection.Find(new BsonDocument()).ToList();
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} -> {p.Price}");
}
