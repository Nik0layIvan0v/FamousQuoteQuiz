using FamousQuoteQuiz.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Controllers
{
    public class QuizController : WebController
    {
        public QuizController()
        {
            //ADD SERVICE!!!
        }

        //GET
        public IActionResult BinaryChoice()
        {
            this.SetModeSelection();
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult BinaryChoice(string data)
        {
            return View();
        }

        //GET
        public IActionResult MultipleChoice()
        {
            this.SetModeSelection();
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult MultipleChoice(string data)
        {
            return View();
        }
    }
}
