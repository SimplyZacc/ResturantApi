using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_os.Models
{
    [Table("Resturants")]
    public class Resturant
    {
        public int ResutrantId { get; set; }
        public string ResturantName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}