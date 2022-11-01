namespace FamousQuoteQuiz.Extensions
{
    using FamousQuoteQuiz.Data;
    using FamousQuoteQuiz.Data.DbInitializer;
    using Microsoft.EntityFrameworkCore;

    public static class ApplicationExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder builder)
        {
            IServiceScope scope = builder.ApplicationServices.CreateScope();
            FamousQuoteQuizDbContext quizDbContext = scope.ServiceProvider.GetRequiredService<FamousQuoteQuizDbContext>();
            quizDbContext.Database.Migrate();
            return builder;
        }

        public static IApplicationBuilder InitializeData(this IApplicationBuilder builder)
        {
            IServiceScope scope = builder.ApplicationServices.CreateScope();
            FamousQuoteQuizDbContext quizDbContext = scope.ServiceProvider.GetRequiredService<FamousQuoteQuizDbContext>();
            quizDbContext.Initialize();
            return builder;
        }
    }
}
