//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pizza_types
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pizza_types()
        {
            this.pizzas = new HashSet<pizza>();
        }
    
        public string pizza_type_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string ingredients { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pizza> pizzas { get; set; }
    }
}
