//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetSure_Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VethubClaim
    {
        public string policyHolderId { get; set; }
        public int claimDetailsId { get; set; }
        public int vetPractiseId { get; set; }
    
        public virtual ClaimDetail ClaimDetail { get; set; }
        public virtual PolicyHolder PolicyHolder { get; set; }
        public virtual VetPractise VetPractise { get; set; }
    }
}
