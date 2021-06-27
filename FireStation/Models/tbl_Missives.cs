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
        [Display(Name = "شناسه بخشنامه")]
        public int MissiveId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "عنوان")]
        public string MissiveTitel { get; set; }

        [Required]
        [Display(Name = "متن")]
        public string MissiveText { get; set; }

        [Display(Name = "آدرس فایل")]
        public string MissiveFileUrl { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime MissiveDate { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "شماره بخشنامه")]
        public string MissiveNumber { get; set; }

        [Display(Name = "کاربر ثبت کننده")]
        public int MissiveUserId { get; set; }

        public virtual tbl_User tbl_User { get; set; }
    }
}
