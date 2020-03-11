using System;
using System.Collections.Generic;

namespace Qian.Shop.Core.Models
{
    public partial class OrderItems
    {
        public int ItemId { get; set; }
        public string OrderNumber { get; set; }
        public string ItemName { get; set; }
        public short? ItemProperty { get; set; }
        public short? ItemSuit { get; set; }
        public int? BookId { get; set; }
        public decimal? ItemPrice { get; set; }
    }
}
