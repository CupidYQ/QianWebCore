using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Qian.Shop.Api
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
            services.AddControllers();
            services.AddDbContext<Core.QianContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);//可以在Logging信息中看到EFCore生成sql中时的敏感数据
                options.UseSqlServer(Configuration.GetConnectionString("DefaultString"));                
            });
            BLL.DIBLLRegister bllRegister = new BLL.DIBLLRegister();
            bllRegister.DIRegister(services);
            //string strType = Configuration.GetSection("ConnectionString:DefaultString").Value;
            //if (strType.Equals("Server=(local)\\MSSQLLcalDB;DataBase=BookStore;Trusted_Connection=True;"))
            //{
                
            //    services.AddTransient<DALFactory.AbsFactoryDAL, DALFactory.SQLFactoryDAL>();
            //}            
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
