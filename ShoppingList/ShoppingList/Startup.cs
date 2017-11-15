using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using ShoppingList.Services;
using ShoppingList.Repositories;

namespace ShoppingList
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            services.AddMvc();
            services.AddScoped<ItemRepository>();
            services.AddScoped<ItemService>();
            services.AddDbContext<ShoppingListContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:ShoppingListConnection"]));
            //services.AddDbContext<ShoppingListContext>(options => options.UseNpgsql(Configuration.GetValue<string>("ConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
