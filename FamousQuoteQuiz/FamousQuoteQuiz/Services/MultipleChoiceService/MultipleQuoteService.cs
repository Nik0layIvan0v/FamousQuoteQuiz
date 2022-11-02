namespace FamousQuoteQuiz.Services.MultipleChoiceService
{
    using FamousQuoteQuiz.Data;
    using FamousQuoteQuiz.Data.EntityModels;
    using FamousQuoteQuiz.Models;
    using static Common.AnswerConstants;

    public class MultipleQuoteService : IMultipleQuoteService
    {
        private readonly FamousQuoteQuizDbContext dbContext;
        private readonly Random random;

        public MultipleQuoteService(FamousQuoteQuizDbContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }

        public MultipleChoiceViewModel GetQuote()
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

            Author? firstRandomAuthor = null;
            while (firstRandomAuthor == null)
            {
                int randomAuthorId = this.random.Next(1, totalAuthorRecords);
                firstRandomAuthor = this.dbContext.Authors.Where(author => author.Id == randomAuthorId).FirstOrDefault();
            }

            Author? secondRandomAuthor = null;
            while (secondRandomAuthor == null)
            {
                int randomAuthorId = this.random.Next(1, totalAuthorRecords);
                secondRandomAuthor = this.dbContext.Authors.Where(author => author.Id == randomAuthorId).FirstOrDefault();
            }

            return new MultipleChoiceViewModel
            {
                QuoteId = quote.Id,
                QuoteText = quote.Content,
                Authors = new List<Author>()
                {
                   correctAutnor,
                   firstRandomAuthor,
                   secondRandomAuthor,
                }
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
                AnswerText = string.Format(WrongAnswer, correctAuthor)
            };
        }
    }
}
