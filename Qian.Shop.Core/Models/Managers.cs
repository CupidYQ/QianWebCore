using System;
using System.Collections.Generic;

namespace Qian.Shop.Core.Models
{
    public partial class Managers
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
