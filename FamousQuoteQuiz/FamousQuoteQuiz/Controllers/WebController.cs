namespace FamousQuoteQuiz.Controllers
{
    using FamousQuoteQuiz.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public abstract class WebController : Controller
    {
        protected ModeSelection GetModeSelection()
        {
            var selectedMode = new ModeSelection()
            {
                IsBinaryModeSelected = false
            };

            var isBinaryModeSelected = this.HttpContext.Session.GetString("BinaryModeIsSelected");
            if (isBinaryModeSelected != null)
            {
                selectedMode.IsBinaryModeSelected = true;
            }

            return selectedMode;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
