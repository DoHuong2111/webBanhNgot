namespace Web_banh_ngot.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILL")]
    public partial class BILL
    {
        [Key]
        public int ID_BILL { get; set; }

        public int? ID_CUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATE_ORDER { get; set; }

        [StringLength(100)]
        public string PAYMENT { get; set; }

        [StringLength(255)]
        public string NOTE_BILL { get; set; }

        [StringLength(100)]
        public string STATUS_BILL { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}
