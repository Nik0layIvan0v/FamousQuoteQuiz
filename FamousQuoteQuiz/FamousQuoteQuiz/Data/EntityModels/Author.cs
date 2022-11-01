namespace FamousQuoteQuiz.Data.EntityModels
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author()
        {
            this.Quotes = new HashSet<Quote>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode(true)]
        public string Name { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
