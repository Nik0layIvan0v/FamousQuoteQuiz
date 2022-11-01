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
            var selectedMode = this.GetModeSelection();
            return View(selectedMode);
        }

        public IActionResult ModeSelection()
        {
            var selectedMode = this.GetModeSelection();
            return View(selectedMode);
        }

        [HttpPost]
        public IActionResult ModeSelection(string modeselection)
        {
            if (modeselection.Equals("BinaryMode") == true)
            {
                this.HttpContext.Session.SetString("BinaryModeIsSelected" , "true");
            }
            else
            {
                this.HttpContext.Session.Remove("BinaryModeIsSelected");
            }

            return RedirectToAction("Index");
        }

        public IActionResult StartQuiz()
        {
            var selectedMode = this.GetModeSelection();
            if (selectedMode.IsBinaryModeSelected == true)
            {
                return RedirectToAction("BinaryChoice", "Quiz");
            }

            return RedirectToAction("MultipleChoice", "Quiz");
        }
    }
}