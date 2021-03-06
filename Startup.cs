using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppPer
{
    public class Startup
    {
        private IConfiguration AppConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder=new ConfigurationBuilder().AddJsonFile("person.json");
            AppConfiguration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           var value=new Person();
           AppConfiguration.Bind(value);
           app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Имя:{value.Name} Фамилия {value.Family}  и Возраст:{value.Age}");
            });
        }
    }
}
