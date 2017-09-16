using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public double OrderTotal { get; set; }
        public bool Paid { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set }
    }

    public class LineItems
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}