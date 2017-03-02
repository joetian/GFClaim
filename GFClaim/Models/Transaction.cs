using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GFClaim.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public float Amount { get; set; }
        public int RevCodeId { get; set; }
        public RevCode RevCode { get; set; }
        public string HCPC { get; set; }

    }
}