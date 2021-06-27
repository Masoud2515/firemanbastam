namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Usage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Usage()
        {
            tbl_Accident = new HashSet<tbl_Accident>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه کاربری")]
        public int UsageId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "عنوان کاربری")]
        public string UsageTitel { get; set; }

        [Display(Name = "توضیحات")]
        public string UsageDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Accident> tbl_Accident { get; set; }
    }
}
