using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Tom.Models
{
    public class Destinations
    {
        [Key]
        public int DestinationID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
