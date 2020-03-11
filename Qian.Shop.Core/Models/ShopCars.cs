using System;
using System.Collections.Generic;

namespace Qian.Shop.Core.Models
{
    public partial class ShopCars
    {
        public int CarId { get; set; }
        public int? BookId { get; set; }
        public int? UserId { get; set; }
        public short? Nums { get; set; }

        public virtual Users User { get; set; }
    }
}
