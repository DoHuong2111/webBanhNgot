namespace Web_banh_ngot.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            BILLs = new HashSet<BILL>();
        }

        [Key]
        public int ID_CUS { get; set; }

        [StringLength(100)]
        public string NAME_CUS { get; set; }

        [StringLength(100)]
        public string EMAIL_CUS { get; set; }

        [StringLength(100)]
        public string ADDRESS_CUS { get; set; }

        [StringLength(15)]
        public string PHONE_CUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL> BILLs { get; set; }
    }
}
