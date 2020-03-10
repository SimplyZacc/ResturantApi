using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_os.Models
{
    [Table("Foods")]
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public double FoodPrice { get; set; }
        public int FoodTypeId { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}