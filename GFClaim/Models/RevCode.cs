using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GFClaim.Models
{
    public class RevCode
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [MaxLength(255)]
        public string Desc { get; set; }
    }
}