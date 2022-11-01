namespace FamousQuoteQuiz.Models
{
    public class RequestAnswerViewModel
    {
        public int AuthorId { get; set; }

        public int QuoteId { get; set; }

        public bool IsYesSelected {get;set;}
    }
}
