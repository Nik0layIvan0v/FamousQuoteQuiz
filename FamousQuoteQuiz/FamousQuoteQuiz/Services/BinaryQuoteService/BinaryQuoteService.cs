namespace FamousQuoteQuiz.Services.BinaryQuoteService
{
    using FamousQuoteQuiz.Data;
    using FamousQuoteQuiz.Data.EntityModels;
    using FamousQuoteQuiz.Models;
    using static Common.AnswerConstants;

    public class BinaryQuoteService : IBinaryQuoteService
    {
        private readonly FamousQuoteQuizDbContext dbContext;
        private readonly Random random;

        public BinaryQuoteService(FamousQuoteQuizDbContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }

        public BinaryQuoteViewModel GetQuote()
        {
            int totalQuoteRecords = this.dbContext.Quotes.Count();
            Quote? quote = null;
            while (quote == null)
            {
                int quoteId = this.random.Next(1, totalQuoteRecords);
                quote = this.dbContext.Quotes.Where(quote => quote.Id == quoteId).FirstOrDefault();
            }

            int correctAuthorId = quote.AuthorId;
            var correctAutnor = this.dbContext.Authors.Where(author => author.Id == correctAuthorId).FirstOrDefault();
            int totalAuthorRecords = this.dbContext.Authors.Count();

            Author? randomAuthor = null;
            while (quote == null)
            {
                int randomAuthorId = this.random.Next(1, totalAuthorRecords);
                randomAuthor = this.dbContext.Authors.Where(author => author.Id == randomAuthorId).FirstOrDefault();
            }

            var yesAnswerId = this.random.Next(1, int.MaxValue) % 2 == 0 ? randomAuthor.Id : correctAuthorId;
            var noAnswerId = this.random.Next(1, int.MaxValue) % 3 == 0 ? correctAuthorId : randomAuthor.Id;

            return new BinaryQuoteViewModel()
            {
                QuoteId = quote.Id,
                Content = quote.Content,
                NoAnswerId = noAnswerId,
                YesAnswerId = yesAnswerId,
                SugestedAuthorName = correctAutnor.Name,
            };
        }

        public AnswerViewModel CheckAnswer(RequestViewModel requestViewModel)
        {

            return new AnswerViewModel()
            {

            };
        }
    }
}
