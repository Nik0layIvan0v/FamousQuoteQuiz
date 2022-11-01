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
            while (randomAuthor == null)
            {
                int randomAuthorId = this.random.Next(1, totalAuthorRecords);
                randomAuthor = this.dbContext.Authors.Where(author => author.Id == randomAuthorId).FirstOrDefault();
            }

            int noAnswerId = 0;
            int yesAnswerId = 0;
            int randomNumber = this.random.Next(1, int.MaxValue);
            if (randomNumber % 2 == 0)
            {
                yesAnswerId = correctAuthorId;
                noAnswerId = randomAuthor.Id;
            }
            else
            {
                yesAnswerId = randomAuthor.Id;
                noAnswerId = correctAuthorId;
            }

            return new BinaryQuoteViewModel()
            {
                QuoteId = quote.Id,
                Content = quote.Content,
                NoAnswerId = noAnswerId,
                YesAnswerId = yesAnswerId,
                SugestedAuthorName = correctAutnor.Name,
            };
        }

        public AnswerViewModel CheckAnswer(RequestAnswerViewModel requestViewModel)
        {
            if (requestViewModel == null)
            {
                throw new ArgumentNullException();
            }

            var answeredAuthor = this.dbContext.Authors
                                               .Where(author => author.Id == requestViewModel.AuthorId)
                                               .Select(author => author.Name)
                                               .FirstOrDefault();

            var correctAuthor = this.dbContext.Quotes
                                              .Where(quote => quote.Id == requestViewModel.QuoteId)
                                              .Select(quote => quote.Author.Name)
                                              .FirstOrDefault();

            if (answeredAuthor == correctAuthor)
            {
                return new AnswerViewModel()
                {
                    AnswerText = string.Format(CorrectAnswer, correctAuthor)
                };
            }

            return new AnswerViewModel()
            {
                AnswerText = string.Format(WrongAnswer, answeredAuthor)
            };
        }
    }
}
