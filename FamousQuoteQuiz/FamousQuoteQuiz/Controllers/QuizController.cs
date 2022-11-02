namespace FamousQuoteQuiz.Controllers
{
    using FamousQuoteQuiz.Models;
    using FamousQuoteQuiz.Services.BinaryQuoteService;
    using FamousQuoteQuiz.Services.MultipleChoiceService;
    using Microsoft.AspNetCore.Mvc;

    public class QuizController : WebController
    {
        private readonly IBinaryQuoteService binaryQuoteService;

        private readonly IMultipleQuoteService multipleQuoteService;

        public QuizController(IBinaryQuoteService binaryQuoteService, IMultipleQuoteService multipleQuoteService)
        {
            this.binaryQuoteService = binaryQuoteService;
            this.multipleQuoteService = multipleQuoteService;
        }

        public IActionResult BinaryChoice()
        {
            this.SetModeSelection();
            var quote = this.binaryQuoteService.GetQuote();
            return View(quote);
        }

        public IActionResult BinaryChoiceResult(RequestAnswerViewModel requestViewModel)
        {
            this.SetModeSelection();
            var answer = this.binaryQuoteService.CheckAnswer(requestViewModel);
            return View(answer);
        }

        public IActionResult MultipleChoice()
        {
            this.SetModeSelection();
            var quoteViewModel = this.multipleQuoteService.GetQuote();
            return View(quoteViewModel);
        }

        [HttpPost]
        public IActionResult MultipleChoice(RequestAnswerViewModel requestViewModel)
        {
            this.SetModeSelection();
            var answer = this.binaryQuoteService.CheckAnswer(requestViewModel);
            return RedirectToAction(nameof(MultipleChoiceResult), answer);
        }

        public IActionResult MultipleChoiceResult(AnswerViewModel answerViewModel)
        {
            this.SetModeSelection();
            return View(answerViewModel);
        }
    }
}
