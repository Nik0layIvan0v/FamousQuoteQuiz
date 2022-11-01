namespace FamousQuoteQuiz
{
    using FamousQuoteQuiz.Data;
    using FamousQuoteQuiz.Extensions;
    using FamousQuoteQuiz.Services.BinaryQuoteService;
    using FamousQuoteQuiz.Services.MultipleChoiceService;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews()
                            .AddRazorRuntimeCompilation();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            builder.Services.AddTransient<IBinaryQuoteService, BinaryQuoteService>();
            builder.Services.AddTransient<IMultipleQuoteService, MultipleQuoteService>();

            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "BinaryModeIsSelected";
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<FamousQuoteQuizDbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();
            if (app.Environment.IsDevelopment() == false)
            {
                app.UseExceptionHandler("/Home/Error")
                   .UseHsts();
            }

            app.ApplyMigrations()
               .InitializeData()
               .UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseAuthorization()
               .UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}