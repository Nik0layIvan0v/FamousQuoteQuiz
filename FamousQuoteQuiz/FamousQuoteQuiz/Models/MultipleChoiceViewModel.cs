namespace FamousQuoteQuiz.Models
{
    using FamousQuoteQuiz.Data.EntityModels;

    public class MultipleChoiceViewModel
    {
        public int QuoteId { get; set; }

        public List<Author> Authors { get; set; }

        public string QuoteText { get; set; }
    }
}
