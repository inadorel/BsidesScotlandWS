using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BsidesScotlandWS.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }

        
    }
}