using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BsidesScotlandWS.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        [Required]
        public string volunteerFirstName { get; set; }
        public string volunteerLastName { get; set; }
        public string volunteerTitle { get; set; }
        public string volunteerEmail { get; set; }
        public string volunteerMobile { get; set; }
        public string volunteerTshirtSize;
        public bool volunteerDinnerAttendee;
        public bool volunteerVegetarian;
        public bool volunteerUnderEighteen;

    }
}
