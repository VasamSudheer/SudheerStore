using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SudheerStore.Models
{
    public class OrderedProduct
    {
        [Key]
        public int ProductId { get; set; }
        public int CustomerOrderId { get; set; }
        public int Quantity { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}