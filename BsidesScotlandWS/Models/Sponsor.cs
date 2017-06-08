using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BsidesScotlandWS.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }
        [Required]
        public string sponsorFirstName { get; set; }
        public string sponsorLastName { get; set; }
        public string sponsorTitle { get; set; }
        public string sponsorEmail { get; set; }
        public string sponsorMobile { get; set; }
        public string sponsorCompanyName { get; set; }
        public string sponsorLevel { get; set; }
        public string sponsorStatus { get; set; }
        public bool contacted { get; set; }
        public bool responded { get; set; }
        public string result { get; set; }
        public string contactedBy { get; set; }
        public bool dinnerAttendee { get; set; }
        public bool vegetarian { get; set; }

        //Foreign Key
        public int AddressId { get; set; }
    }
}