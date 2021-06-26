namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Missives
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MissiveId { get; set; }

        [Required]
        [StringLength(50)]
        public string MissiveTitel { get; set; }

        [Required]
        public string MissiveText { get; set; }

        public string MissiveFileUrl { get; set; }

        [Column(TypeName = "date")]
        public DateTime MissiveDate { get; set; }

        [Required]
        [StringLength(10)]
        public string MissiveNumber { get; set; }

        public int MissiveUserId { get; set; }

        public virtual tbl_User tbl_User { get; set; }
    }
}
