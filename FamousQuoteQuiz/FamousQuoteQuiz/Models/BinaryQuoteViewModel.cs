namespace FamousQuoteQuiz.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BinaryQuoteViewModel
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string SugestedAuthorName {get; set;}

        public int QuoteId { get; set; }

        public int YesAnswerId { get; set; }

        public int NoAnswerId { get; set; }
    }
}
