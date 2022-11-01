namespace FamousQuoteQuiz.Services.MultipleChoiceService
{
    using FamousQuoteQuiz.Data;
    using FamousQuoteQuiz.Models;

    public class MultipleQuoteService : IMultipleQuoteService
    {
        private readonly FamousQuoteQuizDbContext dbContext;
        private readonly Random random;

        public MultipleQuoteService(FamousQuoteQuizDbContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }

        public AnswerViewModel CheckAnswer(RequestAnswerViewModel requestViewModel)
        {
            throw new NotImplementedException();
        }

        public MultipleChoiceViewModel GetQuote()
        {
            throw new NotImplementedException();
        }
    }
}
