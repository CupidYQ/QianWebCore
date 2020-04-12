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
            #region ע�� Swagger
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "�ӿڲ���",
                    Version = "version-01",
                    Description = "QianShopApi����"
                });
            });
            #endregion

            services.AddControllers();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));//ȫ��ע�� ȫ����Ч
            });

            //���ʹ��[ServiceFilter(typeof(CustomActionFilterAttribute))]�������Ա�ǩ ����Ҫ��������ע�����
            services.AddSingleton<CustomActionFilterAttribute>();

            services.AddDbContext<Core.QianContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);//������Logging��Ϣ�п���EFCore����sql��ʱ����������
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

            #region ʹ��Swagger�м��
            app.UseSwagger();
            app.UseSwaggerUI(p => {
                p.SwaggerEndpoint("/swagger/V1/swagger.json", "����");
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
