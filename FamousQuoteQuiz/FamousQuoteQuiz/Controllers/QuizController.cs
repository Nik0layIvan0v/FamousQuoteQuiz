namespace FamousQuoteQuiz.Controllers
{
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

        //[HttpPost]
        //public IActionResult BinaryChoice(BinaryQuoteViewModel binaryQuoteView)
        //{
        //    this.SetModeSelection();
        //    if (this.ModelState.IsValid == false)
        //    {
        //        return this.BinaryChoice();
        //    }

        //    return View();
        //}

        //GET
        public IActionResult MultipleChoice()
        {
            this.SetModeSelection();
            return View();
        }

        [HttpPost]
        public IActionResult MultipleChoice(string data)
        {
            this.SetModeSelection();
            return View();
        }
    }
}
