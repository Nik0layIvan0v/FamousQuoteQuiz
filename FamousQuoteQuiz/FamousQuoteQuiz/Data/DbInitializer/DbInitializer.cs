namespace FamousQuoteQuiz.Data.DbInitializer
{
    using FamousQuoteQuiz.Data.EntityModels;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class DbInitializer
    {
        public static void Initialize(this FamousQuoteQuizDbContext context)
        {
            context.Database.EnsureCreated();
            //if (context.Authors.Any() == true)
            //{
            //    return;
            //}
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string authorsPath = Path.Combine(baseDirectory, "..\\..\\..\\Data\\DbInitializer\\Authors.json");
            string authorJson = File.ReadAllText(authorsPath);
            if (string.IsNullOrEmpty(authorJson) == false)
            {
                var authors = JsonConvert.DeserializeObject<dynamic>(authorJson);
                foreach (var author in authors)
                {
                    var dbAuthor = new Author()
                    {
                        Name = author.Name
                    };

                    context.Authors.Add(dbAuthor);
                }

                context.SaveChanges();
            }

            string quotesPath = Path.Combine(baseDirectory, "..\\..\\..\\Data\\DbInitializer\\Quotes.json");
            string quotesJson = File.ReadAllText(quotesPath);
            if (string.IsNullOrEmpty(quotesJson) == false)
            {
                var quotes = JsonConvert.DeserializeObject<dynamic>(quotesJson);
                foreach (var quote in quotes)
                {
                    int? authorId = quote.AuthorID;
                    if (authorId != null)
                    {
                        var author = context.Authors.Where(author => author.Id == authorId).FirstOrDefault();
                        string quoteContet = quote.Content;
                        var dbQuote = new Quote()
                        {
                            Author = author,
                            Content = quoteContet.Length <= 50 ? quoteContet : quoteContet.Substring(0, 50)
                    };

                    context.Quotes.Add(dbQuote);
                }
            }
            context.SaveChanges();
        }
        }
    }
}
