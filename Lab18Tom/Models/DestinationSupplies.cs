using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Tom.Models
{
    public class DestinationSupplies
    {
        [Key]
        public int DestinationID { get; set; }
        public int SuppyID { get; set; }
        public Destinations Destinations { get; set; }
        public Supplies Supplies { get; set; }
    }
}
