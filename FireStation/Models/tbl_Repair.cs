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
        [Display(Name = "شناسه تعمیر")]
        public int RepairId { get; set; }

        [Display(Name = "شرح تعمیرات")]
        public string RepairDescription { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ تعمیر")]
        public DateTime RepairDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "عنوان")]
        public string RepairTitel { get; set; }

        [Display(Name = "شناسه تجهیزات")]
        public int MaterialId { get; set; }

        [Display(Name = "شناسه ایستگاه")]
        public int StateId { get; set; }

        public virtual tbl_Material tbl_Material { get; set; }

        public virtual tbl_State tbl_State { get; set; }
    }
}
