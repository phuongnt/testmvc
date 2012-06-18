using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC4.data
{
    [Table("Airline")]
    public class Airline
    {
        [Key]
        public Int64 ID { get; set; }

        [StringLength(2)]
        public String AirlineCode { get; set; }


        [StringLength(50)]
        public string Name { get; set; }


        public string AvailableNames { get; set; }

    }
}