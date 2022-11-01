namespace FamousQuoteQuiz.Services.MultipleChoiceService
{
    using FamousQuoteQuiz.Models;

    public interface IMultipleQuoteService
    {
        MultipleChoiceViewModel GetQuote();

        AnswerViewModel CheckAnswer(RequestAnswerViewModel requestViewModel);
    }
}
