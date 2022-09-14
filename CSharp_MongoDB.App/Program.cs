using MongoDB.Driver;

const string CONNECTION_STRING = "mongodb://localhost:27017";
var client = new MongoClient(CONNECTION_STRING);

var db = client.GetDatabase("students_db");
var collections = db.ListCollections();
while (collections.MoveNext())
{
    foreach (var document in collections.Current)
    {
        foreach (var element in document.Elements)
        {
            Console.WriteLine($"{element.Name} -> {element.Value}");
        }
        Console.WriteLine();
    }
}
