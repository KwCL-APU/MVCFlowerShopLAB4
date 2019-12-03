using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFlowerShop.Models
{
    public class Flower
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Flower Name")]
        //modify the column name in the web page
        public string FlowerName { get; set; }

        [Display(Name = "Produced Date")]
        [DataType(DataType.Date)] //modify the data type in column
        public DateTime FlowerProducedDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]

        [Display(Name = "Type of Flower")]
        public string Type { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column("Price",TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Range(1.0, 10.0)]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}
