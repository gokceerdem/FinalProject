using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
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
            //aşağıdaki yapıyı(services.AddControllers(),services.AddSingleton ) farklı bir mimariye taşıyacağız.
            //Bu mimariler : dotnet builtin ioc container yapısı yokken kullanılıyordu
            //Autofac, ninject, castlewindsor,structuremap, lightinject, dryinject
            //AOP kodlama yapacağız 
            services.AddControllers();
            services.AddSingleton<IProductService,ProductManager>(); //arka planda referans oluşturur
                                                                     //IOC new() yapar
                                                                     //birisi IProductService isterse arka planda new ProductManager oluştur bunu ver
                                                                     //1 tane ProductManager oluşturuyor 1000 tane client bile gelse aynı productmanager kullanılacak
                                                                     //fakat data tutmuyan bir yapı olması lazım
                                                                     //örneğin sepet instance için kullanamazsınız yoksa tüm müşterilerin sepetleri birbirine girer
            services.AddSingleton<IProductDal, EfProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
