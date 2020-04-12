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
using Qian.Shop.Api.Utility;

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
            #region 注册 Swagger
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "接口测试",
                    Version = "version-01",
                    Description = "QianShopApi测试"
                });
            });
            #endregion

            services.AddControllers();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));//全局注册 全局生效
            });

            //如果使用[ServiceFilter(typeof(CustomActionFilterAttribute))]这种特性标签 则需要在容器里注册服务
            services.AddSingleton<CustomActionFilterAttribute>();

            services.AddDbContext<Core.QianContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);//可以在Logging信息中看到EFCore生成sql中时的敏感数据
                options.UseSqlServer(Configuration.GetConnectionString("DefaultString"));                
            });
            //services.AddTransient<CustomExceptionFilterAttribute>();
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

            #region 使用Swagger中间件
            app.UseSwagger();
            app.UseSwaggerUI(p => {
                p.SwaggerEndpoint("/swagger/V1/swagger.json", "测试");
            });
            #endregion

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
