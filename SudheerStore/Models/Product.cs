using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SudheerStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(45, ErrorMessage = "The maximum length must be upto 45 characters only")]
        public string Name { get; set; }

        [RegularExpression(@"^[-+]?\d*$", ErrorMessage = "Has to be decimal with two decimal points")]
        [Range(50, 100000, ErrorMessage = "The maximum possible value should be upto 5 digits")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        [Display(Name = "Updated At")]
        [Column(TypeName = "datetime2")]
        public System.DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public byte[] Product_Image { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Stock")]
        public int Stock { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Category Category { get; set; }
      
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}