namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Injured
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Injured()
        {
            tbl_AccidentInjured = new HashSet<tbl_AccidentInjured>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InjuredID { get; set; }

        [Required]
        [StringLength(50)]
        public string InjuredName { get; set; }

        [Required]
        [StringLength(50)]
        public string InjuredLastName { get; set; }

        public bool InjuredSex { get; set; }

        public bool InjuredType { get; set; }

        public bool InjuredTypeinjury { get; set; }

        [Required]
        public string InjuredDescription { get; set; }

        public string InjuredLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentInjured> tbl_AccidentInjured { get; set; }
    }
}
