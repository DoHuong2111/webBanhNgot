namespace Web_banh_ngot.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [Key]
        public int ID_US { get; set; }

        [StringLength(100)]
        public string USERNAME { get; set; }

        [StringLength(100)]
        public string FULL_NAME { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(100)]
        public string PASSWORD_ { get; set; }
    }
}
