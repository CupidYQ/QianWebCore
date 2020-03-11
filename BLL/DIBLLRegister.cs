using Microsoft.Extensions.DependencyInjection;
using IBLL;
using BLL.Logic;
using IDAL;
using IDAL.IDataService;
using DAL;
using DAL.DataService;

namespace BLL
{
    public class DIBLLRegister
    {
        public void DIRegister(IServiceCollection services)
        {
            // 用于实例化DalService对象，获取上下文对象
            //services.AddTransient(typeof(IDALService<>), typeof(DALService<>));

            //配置一个依赖注入映射关系 
            services.AddScoped<IBooksService, BooksServiceBLL>();
            services.AddScoped<IBooksServiceDAL, BooksServiceDAL>();
        }
    }
}
