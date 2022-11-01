namespace FamousQuoteQuiz.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : WebController
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            this.SetModeSelection();
            return View();
        }

        public IActionResult ModeSelection()
        {
            this.SetModeSelection();
            return View();
        }

        [HttpPost]
        public IActionResult ModeSelection(string modeselection)
        {
            if (modeselection.Equals("BinaryMode") == true)
            {
                this.HttpContext.Session.SetString("BinaryModeIsSelected", "");
                this.ViewData["multipleSelection"] = null;
            }
            else
            {
                this.HttpContext.Session.Remove("BinaryModeIsSelected");
                this.ViewData["multipleSelection"] = "Selected";
            }

            return RedirectToAction("Index");
        }

        public IActionResult StartQuiz()
        {
            this.SetModeSelection();
            var selectedMode = this.ViewData["multipleSelection"];
            if (selectedMode == null)
            {
                return RedirectToAction("BinaryChoice", "Quiz");
            }

            return RedirectToAction("MultipleChoice", "Quiz");
        }
    }
}