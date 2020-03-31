using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.IDataService
{
    public interface IRegisterService
    {
        Task<string> Register(Qian.Models.UserInfo userInfo);
    }
}
