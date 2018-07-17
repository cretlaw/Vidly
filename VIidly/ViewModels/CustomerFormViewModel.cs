using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VIidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //public Customer Customer { get; set; }


        public int? Id { get; set; }

        //Overriding null set by Entity when creating SQL DB
        [Required]
        //Setting the max string to 225 chars
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribe To Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }


        //foreign Key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }


        [Display(Name = "Date of Birth")]
        //Custom Validation
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
        }
    }
}