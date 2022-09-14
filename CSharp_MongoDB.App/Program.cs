using MongoDB.Driver;

const string CONNECTION_STRING = "mongodb://localhost:27017";
var db = new MongoClient(CONNECTION_STRING);
var bases = db.ListDatabases();
while (bases.MoveNext())
{
    foreach (var item in bases.Current)
    {
        foreach (var element in item.Elements)
        {
            Console.WriteLine($"{element.Name} -> {element.Value}");
        }
        Console.WriteLine("--- --- ---");
    }
}

