using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BsidesScotlandWS.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set;  }
        [Required]
        public string speakerFirstName { get; set;  }
        public string speakerLastName { get; set; }
        public string speakerTitle { get; set; }
        public string speakerEmail { get; set; }
        public string speakerMobile { get; set; }
        public bool dinnerAttendee { get; set; }
        public bool vegetarian { get; set; }
        public string tshirtSize { get; set; }
        public bool underEighteen { get; set; }
        public string emergencyContactName { get; set; }
        public string emergencyContactNumber { get; set; }
        public string gender { get; set; }
        public string talkTitle { get; set; }
        public bool international { get; set; }
        public DateTime dateSubmitted { get; set; }
        public bool expReq { get; set; }
        public string track { get; set; }
        public bool talkAccepted { get; set; }
        public bool confirmed { get; set; }
    }
}