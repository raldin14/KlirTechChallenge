using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class Promotions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Promotion { get; set; }

        //Navigation Properties
        public List<Products> Products { get; set; }
    }
}
