namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccidentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_AccidentType()
        {
            tbl_Accident = new HashSet<tbl_Accident>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه نوع حادثه")]
        public int AccidentTypeId { get; set; }

        [StringLength(50)]
        [Display(Name = "عنوان نوع حادثه")]
        public string AccidentTypeTitel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Accident> tbl_Accident { get; set; }
    }
}
