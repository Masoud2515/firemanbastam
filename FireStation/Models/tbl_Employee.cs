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
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeCode { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeLastName { get; set; }

        [Required]
        [StringLength(15)]
        public string EmployeePhone { get; set; }

        [StringLength(50)]
        public string EmployeeAdress { get; set; }

        public string EmployeePicUrl { get; set; }

        public int StateId { get; set; }

        [StringLength(50)]
        public string EmployeeFName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeMCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime EmployeeBirthdate { get; set; }

        public bool EmployeeSex { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeWork { get; set; }

        [Column(TypeName = "date")]
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
