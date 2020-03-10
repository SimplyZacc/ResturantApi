using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_os.Models
{
    [Table("Resturants")]
    public class ResturantMenu
    {
        public int ResutrantMenuId { get; set; }
        public string ResturantMenuName { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}