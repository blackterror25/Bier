//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bier.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bier()
        {
            this.Item = new HashSet<Item>();
        }
    
        public int Id { get; set; }
        public int InhoudId { get; set; }
        public string AspNetUsersId { get; set; }
        public string Naam { get; set; }
        public string Label { get; set; }
        public string Temperatuur { get; set; }
        public string Barcode { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Item { get; set; }
        public virtual Inhoud Inhoud { get; set; }
    }
}
