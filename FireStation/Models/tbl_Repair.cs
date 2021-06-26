namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Repair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RepairId { get; set; }

        public string RepairDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime RepairDate { get; set; }

        [Required]
        [StringLength(50)]
        public string RepairTitel { get; set; }

        public int MaterialId { get; set; }

        public int StateId { get; set; }

        public virtual tbl_Material tbl_Material { get; set; }

        public virtual tbl_State tbl_State { get; set; }
    }
}
