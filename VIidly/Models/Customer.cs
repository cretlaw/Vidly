using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //Overriding null set by Entity when creating SQL DB
        [Required]
        //Setting the max string to 225 chars
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribe To Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        //Navigation Property which can load other info into DB
        public MembershipType MembershipType { get; set; }

        //foreign Key
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display (Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

    }
}
