using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GFClaim.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime? ServiceFrom { get; set; }
        public DateTime? ServiceThru { get; set; }
        public DateTime BillDate { get; set; }

    }
}