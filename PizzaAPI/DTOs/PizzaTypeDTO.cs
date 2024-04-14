using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaAPI.DTOs
{
    public class PizzaTypeDTO
    {
        public string pizza_type_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string ingredients { get; set; }
    }
}