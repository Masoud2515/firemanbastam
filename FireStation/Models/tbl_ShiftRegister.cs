namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ShiftRegister
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ShiftRegister()
        {
            tbl_ShiftRegisterEmployee = new HashSet<tbl_ShiftRegisterEmployee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه ثبت شیفت")]
        public int ShiftRegisterid { get; set; }

        [Required]
        [Display(Name = "توضیحات شیفت")]
        public string ShiftRegisterDec { get; set; }

        [Display(Name = "فرمانده شیفت")]
        public int ShiftRegisterCommandor { get; set; }

        [Display(Name = "زمان شروع")]
        public TimeSpan ShiftRegisterTimeStart { get; set; }

        [Display(Name = "زمان اتمام")]
        public TimeSpan ShiftRegisterTimeEnd { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ شروع")]
        public DateTime ShiftRegisterDateStart { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ اتمام")]
        public DateTime ShiftRegisteridDateEnd { get; set; }

        [Display(Name = "آدرس فایل")]
        public string ShiftRegisterurl { get; set; }

        [Display(Name = "شناسه شیفت")]
        public int ShiftRegisterShifId { get; set; }

        public virtual tbl_shift tbl_shift { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ShiftRegisterEmployee> tbl_ShiftRegisterEmployee { get; set; }
    }
}
