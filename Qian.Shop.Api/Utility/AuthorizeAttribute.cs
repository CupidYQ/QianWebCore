using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qian.Shop.Api.Utility
{
    public class AuthorizeAttribute : Attribute, IAuthorizeData
    {
        public string AuthenticationSchemes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Policy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
