namespace Web_banh_ngot.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            Photos = new HashSet<PHOTO>();
        }

        [Key]
        public int ID_PR { get; set; }

        public int? ID_TYPE { get; set; }

        [StringLength(255)]
        public string NAME_PR { get; set; }

        [StringLength(20)]
        public string UNIT { get; set; }

        public decimal? PRICE { get; set; }

        public decimal? PRICE_OLD { get; set; }

        [StringLength(255)]
        public string DESCRIPTIONS { get; set; }

        [StringLength(255)]
        public string IMAGE { get; set; }

        public bool? NEW { get; set; }

        public bool? HOT { get; set; }

        [StringLength(10)]
        public string SIZE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHOTO> Photos { get; set; }

        public virtual TYPE_PRODUCT TYPE_PRODUCT { get; set; }
       
    }
}
