using MongoDB.Bson;
using MongoDB.Driver;

const string CONNECTION_STRING = "mongodb://localhost:27017";
var client = new MongoClient(CONNECTION_STRING);

var db = client.GetDatabase("products_db");
var collection = db.GetCollection<BsonDocument>("products");
var cursor = collection.FindSync(new BsonDocument());
while (cursor.MoveNext())
{
    foreach (var document in cursor.Current)
    {
        foreach (var element in document.Elements)
        {
            Console.Write($"{element.Name} -> ");
            if (element.Value.IsBsonDocument)
            {
                foreach (var item in element.Value.AsBsonDocument)
                {
                    Console.WriteLine($"{item.Name} -> {item.Value}");
                }
            }
            else
            {
                Console.WriteLine($"{element.Value}");
            }
        }
        Console.WriteLine();
    }
}
