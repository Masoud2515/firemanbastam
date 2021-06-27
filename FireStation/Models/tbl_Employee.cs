namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Employee()
        {
            tbl_Accident = new HashSet<tbl_Accident>();
            tbl_Accident1 = new HashSet<tbl_Accident>();
            tbl_AccidentEmplyoee = new HashSet<tbl_AccidentEmplyoee>();
            tbl_Leave = new HashSet<tbl_Leave>();
            tbl_Leave1 = new HashSet<tbl_Leave>();
            tbl_ShiftRegisterEmployee = new HashSet<tbl_ShiftRegisterEmployee>();
            tbl_User = new HashSet<tbl_User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه کارمندی")]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "کد پرسنلی")]
        public string EmployeeCode { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "نام")]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "نام خانوادگی")]
        public string EmployeeLastName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "تلفن")]
        public string EmployeePhone { get; set; }

        [StringLength(50)]
        [Display(Name = "آدرس")]
        public string EmployeeAdress { get; set; }

        [Display(Name = "عکس پروفایل")]
        public string EmployeePicUrl { get; set; }

        [Display(Name = "شناسه ایستگاه")]
        public int StateId { get; set; }

        [StringLength(50)]
        [Display(Name = "نام پدر")]
        public string EmployeeFName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "کد ملی")]
        public string EmployeeMCode { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ تولد")]
        public DateTime EmployeeBirthdate { get; set; }

        [Display(Name = "جنسیت")]
        public bool EmployeeSex { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "رده کاری")]
        public string EmployeeWork { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ استخدام")]
        public DateTime EmployeeDateRegistered { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Accident> tbl_Accident { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Accident> tbl_Accident1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentEmplyoee> tbl_AccidentEmplyoee { get; set; }

        public virtual tbl_State tbl_State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Leave> tbl_Leave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Leave> tbl_Leave1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ShiftRegisterEmployee> tbl_ShiftRegisterEmployee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_User> tbl_User { get; set; }
    }
}
