using System;
using System.Collections.Generic;

namespace Qian.Shop.Core.Models
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorsName { get; set; }
        public string BookContent { get; set; }
        public string BookType { get; set; }
        public bool BookState { get; set; }
        public decimal? MarketPrice { get; set; }
        public decimal? PromotionPrice { get; set; }
        public decimal? GreatPrice { get; set; }
        public decimal? SeckillPrice { get; set; }
        public string BookImg { get; set; }
        public bool IsHot { get; set; }
        public string Suit { get; set; }
        public short Stock { get; set; }
        public DateTime AddTime { get; set; }
    }
}
