using Qian.Models;
using Qian.Shop.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataService
{
    public class RegisterServiceDAL : DALService<Qian.Shop.Core.Models.Users>, IDAL.IDataService.IRegisterService
    {
        public RegisterServiceDAL(QianContext context) : base(context)
        {

        }

        public Task<string> Register(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
