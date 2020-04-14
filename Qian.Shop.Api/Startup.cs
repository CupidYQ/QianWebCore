using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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

            //�����еķ�������Ч
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));//ȫ��ע�� ȫ����Ч
            });

            #region JWT��Ȩ��Ȩ
            //1. Nuget����������Microsoft.AspNetCore.Authentication.JwtBearer
            //services.AddAuthentication
            var ValidAudience = this.Configuration["audience"];
            var ValidIssuer = this.Configuration["issuer"];
            var SecurityKey = this.Configuration["SecurityKey"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Ĭ����Ȩ��������
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//�Ƿ���֤Issuer
                        ValidateAudience = true,//�Ƿ���֤Audience
                        ValidateLifetime = true, //�Ƿ���֤ʧЧʱ��
                        ValidateIssuerSigningKey = true, //�Ƿ���֤SecurityKey
                        ValidAudience = ValidAudience,//Audience
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey)),//�õ�SecurityKey

                        //�Զ���У����򣬿����µ�¼��֮ǰ��Ч
                        //AudienceValidator = (m,n,z) => 
                        //{
                        //    return m != null && m.FirstOrDefault().Equals(this.Configuration["audience"]);
                        //}
                    };
                });
            #endregion

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
