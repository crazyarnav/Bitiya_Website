using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BITIYA_WebSite.Models
{
    public class Person
    {
        [Required(ErrorMessage="Required...")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required...")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Required...")]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage="Invalid Email...")]
        public string Email { get; set; }

        [Display(Name="Phone")]
        public string Phone { get; set; }

        [Display(Name = "What is your availability?")]
        public string Availability { get; set; }

        [Display(Name = "Are you interested in volunteering for events?")]
        public string Volunteer { get; set; }

        [Display(Name = "Are you interested in fund raising?")]
        public string Fundraising { get; set; }

        [Display(Name = "Are there any particular interests or skills /\nthat you would like us to know about?")]
        public string Interests { get; set; }

        [Display(Name = "Any Bitiya Ideas??")]
        public string Suggestions { get; set; }


    }
}