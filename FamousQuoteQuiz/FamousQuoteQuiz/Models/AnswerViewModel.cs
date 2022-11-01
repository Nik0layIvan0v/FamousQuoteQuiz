namespace FamousQuoteQuiz.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AnswerViewModel
    {
        [Required]
        public string AnswerText { get; set; }

    }
}
