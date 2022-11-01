namespace FamousQuoteQuiz.Controllers
{
    using FamousQuoteQuiz.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public abstract class WebController : Controller
    {
        protected internal void SetModeSelection()
        {
            this.ViewData["multipleSelection"] = "Selected";
            var isBinaryModeSelected = this.HttpContext.Session.GetString("BinaryModeIsSelected");
            if (isBinaryModeSelected != null)
            {
                this.ViewData["multipleSelection"] = null;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
