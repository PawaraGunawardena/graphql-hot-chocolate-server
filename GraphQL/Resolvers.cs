
public class Resolvers {
    public String GetFormattedDate([Parent] Book book) => book.PublishedDate.ToShortDateString();
}