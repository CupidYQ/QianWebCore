using System;
using System.Collections.Generic;

namespace Qian.Shop.Core.Models
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
            ShopCars = new HashSet<ShopCars>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
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

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<ShopCars> ShopCars { get; set; }
    }
}
