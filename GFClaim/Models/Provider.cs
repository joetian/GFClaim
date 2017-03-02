using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GFClaim.Models
{
    public class Provider
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public string Address1 { get; set; }
        
        public string Address2 { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Zipcode { get; set; }
        
        public string Phone { get; set; }
        
        public string TaxId { get; set; }
    }
}