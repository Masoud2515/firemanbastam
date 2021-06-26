namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl-User")]
    public partial class tbl_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_User()
        {
            tbl_Accident = new HashSet<tbl_Accident>();
            tbl_Missives = new HashSet<tbl_Missives>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string UserUserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(10)]
        public string UserRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Accident> tbl_Accident { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Missives> tbl_Missives { get; set; }
    }
}
