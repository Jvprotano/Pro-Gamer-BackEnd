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
    
    public partial class Account
    {
        public int Id { get; set; }
        public int AccountTypeId { get; set; }
        public int UserId { get; set; }
        public string Digit { get; set; }
        public string Number { get; set; }
        public string Agency { get; set; }
        public string NomeBank { get; set; }
    
        public virtual AccountType AccountType { get; set; }
        public virtual User User { get; set; }
    }
}
