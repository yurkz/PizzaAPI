﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaAPI.DTOs
{
    public class PizzaDTO
    {
        public string pizza_id { get; set; }
        public string pizza_type_id { get; set; }
        public string size { get; set; }
        public decimal? price { get; set; }
    }
}