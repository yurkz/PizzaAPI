using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaAPI.DTOs
{
    public class OrderDetailsDTO
    {
        public long order_details_id { get; set; }
        public long order_id { get; set; }
        public string pizza_id { get; set; }
        public long quantity { get; set; }
    }

}