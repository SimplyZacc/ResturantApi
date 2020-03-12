using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_os.Models
{
    [Table("OrderTypes")]
    public class OrderType
    {
        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}