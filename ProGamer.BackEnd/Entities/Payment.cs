//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProGamer.BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            this.Purchase = new HashSet<Purchase>();
        }
    
        public int Id { get; set; }
        public string LastFourDigits { get; set; }
        public string CardCpf { get; set; }
        public string CardFlag { get; set; }
        public decimal Value { get; set; }
        public int NumberInstallments { get; set; }
        public string PaymentRequest { get; set; }
        public string PaymentReponse { get; set; }
        public System.DateTime DateUtcInsert { get; set; }
        public Nullable<System.DateTime> DateUtcUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
