using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaAPI.DTOs
{
    public class OrderDTO
    {
        public long order_id { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
    }




    public class AddOrderDTO
    {
        public string pizza { get; set; }
        public long quantity { get; set; }
    }
}