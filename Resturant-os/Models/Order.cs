using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_os.Models
{
    [Table("Orders")]
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}