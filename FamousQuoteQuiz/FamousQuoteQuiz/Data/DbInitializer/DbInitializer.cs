namespace FamousQuoteQuiz.Data.DbInitializer
{
    using FamousQuoteQuiz.Data.EntityModels;

    public static class DbInitializer
    {
        public static void Initialize(this FamousQuoteQuizDbContext context)
        {
            context.Database.EnsureCreated();

            //TEST IF EF CORE WORK!
            var author = new Author()
            {
                Name = "Test entityFramework"
            };
            
            context.Authors.Add(author);
            context.SaveChanges();

            //TODO: Initialize data!!!
            if (context.Authors.Any() == true)
            {
                return;
            }
        }
    }
}
