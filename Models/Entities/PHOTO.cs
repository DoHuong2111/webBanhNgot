namespace Web_banh_ngot.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHOTO")]
    public partial class PHOTO
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string NAME_PHOTO { get; set; }

        public int? ID_PR { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
