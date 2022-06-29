using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff;
using TeamLearningEnglish.EfStuff.Repository;

namespace TeamLearningEnglish
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = 
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TeamLearningEnglish;Integrated Security=True;"; 
            // where does the database locate (catalog=TeamLearningEnglish -- it's database name)
            services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));
            // connected the database

            services.AddScoped<BooksRepository>(x =>
                new BooksRepository(x.GetService<WebDbContext>()));

            services.AddScoped<MessageRepository>(x =>
                new MessageRepository(x.GetService<WebDbContext>()));

            services.AddScoped<VideoNotesRepository>(x =>
                new VideoNotesRepository(x.GetService<WebDbContext>()));

            services.AddScoped<WordsRepository>(x =>
                new WordsRepository(x.GetService<WebDbContext>()));

            services.AddScoped<WordCommentRepository>(x =>
                new WordCommentRepository(x.GetService<WebDbContext>()));

            services.AddScoped<UserRepository>(x =>
                new UserRepository(x.GetService<WebDbContext>()));

            

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
