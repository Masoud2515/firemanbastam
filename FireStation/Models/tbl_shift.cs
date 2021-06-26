namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_shift
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_shift()
        {
            tbl_ShiftRegister = new HashSet<tbl_ShiftRegister>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShiftId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShiftName { get; set; }

        public int StateId { get; set; }

        public virtual tbl_State tbl_State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ShiftRegister> tbl_ShiftRegister { get; set; }
    }
}
