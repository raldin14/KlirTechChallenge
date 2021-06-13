using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public Decimal Price { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public Decimal Total { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Promotion_Applied { get; set; }
    }
}
