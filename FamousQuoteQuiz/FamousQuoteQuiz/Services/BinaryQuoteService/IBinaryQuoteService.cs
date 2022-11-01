namespace FamousQuoteQuiz.Services.BinaryQuoteService
{
    using FamousQuoteQuiz.Models;

    public interface IBinaryQuoteService
    {
        BinaryQuoteViewModel GetQuote();

        AnswerViewModel CheckAnswer(RequestViewModel requestViewModel);
    }
}
