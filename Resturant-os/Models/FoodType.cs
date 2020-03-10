using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_os.Models
{
    [Table("FoodTypes")]
    public class FoodType
    {
        public int FoodTypeId { get; set; }
        public string FoodTypeName { get; set; }
        public int MenuId { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}