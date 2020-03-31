using System;
using System.Collections.Generic;
using System.Text;

namespace Qian.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Provice { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
