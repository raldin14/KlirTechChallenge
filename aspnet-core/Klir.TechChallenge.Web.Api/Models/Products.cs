using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public Decimal Price { get; set; }

        //Navigation Properties
        public int? PromotionId { get; set; }
        public Promotions Promotions { get; set; }
    }
}
