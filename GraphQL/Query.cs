using System.Text.Json;
using System.Text.Json.Serialization;

public class Query
{
    public List<Book> Books(string nameContains="")  {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
        return books.Where(book => book.Name.IndexOf(nameContains) >= 0 ).ToList();
    }
}

public class BookType: ObjectType<Book> {
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field("publishedDate").ResolveWith<Resolvers> (
            resolver => resolver.GetFormattedDate(default!)
        );
    }
}