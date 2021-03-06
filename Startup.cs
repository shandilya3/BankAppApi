﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using BankAPI.Dal;
using Microsoft.Extensions.Configuration;

namespace BankAPI
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<DataContext>();


            services.AddMvcCore().AddJsonFormatters();

            services.AddCors();

           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
           
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var builder = new ConfigurationBuilder()
                         .SetBasePath(env.ContentRootPath)
                         .AddEnvironmentVariables();
           
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

        }
    }
}
