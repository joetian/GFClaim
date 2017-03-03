using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GFClaim.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? Birthday { get; set; }
        
        [MaxLength(9)]
        [RegularExpression(@"[1-9][0-9]*")]
        public string SSN { get; set; }

        [MaxLength(128)]
        public string InsurName { get; set; }

        public string InsurGroupNum { get; set; }
        
        public string InsurCardNum { get; set; }
        
        [MaxLength(128)]
        public string Address1 { get; set; }

        [MaxLength(128)]
        public string Address2 { get; set; }

        [MaxLength(128)]
        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(10)]
        [RegularExpression(@"^(?!0+$)[0-9]{5,5}$")]
        public string Zipcode { get; set; }

        [Phone]
        public string Phone { get; set; }

        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$")]
        public string Email { get; set; }
    }
}