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
        public int ShiftRegisterid { get; set; }

        [Required]
        public string ShiftRegisterDec { get; set; }

        public int ShiftRegisterCommandor { get; set; }

        public TimeSpan ShiftRegisterTimeStart { get; set; }

        public TimeSpan ShiftRegisterTimeEnd { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShiftRegisterDateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShiftRegisteridDateEnd { get; set; }

        public string ShiftRegisterurl { get; set; }

        public int ShiftRegisterShifId { get; set; }

        public virtual tbl_shift tbl_shift { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ShiftRegisterEmployee> tbl_ShiftRegisterEmployee { get; set; }
    }
}
