namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_State
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_State()
        {
            tbl_AccidentStation = new HashSet<tbl_AccidentStation>();
            tbl_Employee = new HashSet<tbl_Employee>();
            tbl_Repair = new HashSet<tbl_Repair>();
            tbl_shift = new HashSet<tbl_shift>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StateId { get; set; }

        [Required]
        [StringLength(50)]
        public string StateName { get; set; }

        [Required]
        public string StateAdress { get; set; }

        [Required]
        [StringLength(20)]
        public string StateTel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentStation> tbl_AccidentStation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Employee> tbl_Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Repair> tbl_Repair { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_shift> tbl_shift { get; set; }
    }
}
