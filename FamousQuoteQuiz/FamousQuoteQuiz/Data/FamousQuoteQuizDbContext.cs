namespace FamousQuoteQuiz.Data
{
    using FamousQuoteQuiz.Data.EntityModels;
    using Microsoft.EntityFrameworkCore;

    public class FamousQuoteQuizDbContext : DbContext
    {
        public FamousQuoteQuizDbContext(DbContextOptions<FamousQuoteQuizDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Quote> Quotes { get; set; }
    }
}
