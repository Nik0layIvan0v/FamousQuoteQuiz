namespace FamousQuoteQuiz.Data.EntityModels
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class Quote
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(true)]
        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
