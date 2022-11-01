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

        //GET
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

        //GET
        public IActionResult MultipleChoice()
        {
            this.SetModeSelection();
            var quoteViewModel = this.multipleQuoteService.GetQuote();
            return View(quoteViewModel);
        }


        public IActionResult MultipleChoiceResult(string data)
        {
            this.SetModeSelection();
            return View();
        }
    }
}
