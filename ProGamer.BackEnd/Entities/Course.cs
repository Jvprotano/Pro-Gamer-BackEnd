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
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.CourseRating = new HashSet<CourseRating>();
            this.Purchase = new HashSet<Purchase>();
        }
    
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int CourseCategoryId { get; set; }
        public int Duration { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public System.DateTime DateUtcInsert { get; set; }
        public Nullable<System.DateTime> DateUtcUpdate { get; set; }
    
        public virtual CourseCategory CourseCategory { get; set; }
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseRating> CourseRating { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
