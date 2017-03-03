using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GFClaim.Models
{
    public class ProviderType
    {
        [Display(Name="Provider Type")]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Desc { get; set; }
    }
}