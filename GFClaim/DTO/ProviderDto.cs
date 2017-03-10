using GFClaim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GFClaim.DTO
{
    public class ProviderDto
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

        [Phone]
        public string Phone { get; set; }

        public string TaxIdentity { get; set; }
        public int ProviderTypeId { get; set; }
    }
}