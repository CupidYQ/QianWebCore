using System;
using System.Collections.Generic;

namespace Qian.Shop.Core.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int? UserId { get; set; }
        public decimal? Osprice { get; set; }
        public string ConsigneeAddress { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneePhone { get; set; }
        public short OrderStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ReceivingDate { get; set; }

        public virtual Users User { get; set; }
    }
}
