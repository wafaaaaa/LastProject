//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYJ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY()
        {
            this.CHARTs = new HashSet<CHART>();
            this.GOALACTUALs = new HashSet<GOALACTUAL>();
            this.SUBCATEGORies = new HashSet<SUBCATEGORY>();
            this.WORKSTREAMs = new HashSet<WORKSTREAM>();
        }


        [Display(Name = "Category")]
        public int categoryID { get; set; }
        [Display(Name = "Category")]
        public string categoryName { get; set; }
        [Display(Name = "Workstream")]
        public Nullable<int> workstreamID { get; set; }
    
        public virtual WORKSTREAM WORKSTREAM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHART> CHARTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOALACTUAL> GOALACTUALs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBCATEGORY> SUBCATEGORies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WORKSTREAM> WORKSTREAMs { get; set; }
    }
}
