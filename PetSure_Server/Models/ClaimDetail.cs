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
    
    public partial class ClaimDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClaimDetail()
        {
            this.ph_vp_claim = new HashSet<ph_vp_claim>();
        }
    
        public int claimId { get; set; }
        public string claimPetName { get; set; }
        public string claimMicrochip { get; set; }
        public string claimBreed { get; set; }
        public decimal claimAmount { get; set; }
        public int claimVetHubRef { get; set; }
        public int claimRefNo { get; set; }
        public int claimNo { get; set; }
        public string claimStatus { get; set; }
        public System.DateTime claimSubmittedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ph_vp_claim> ph_vp_claim { get; set; }
    }
}
