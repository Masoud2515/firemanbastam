namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Organizations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Organizations()
        {
            tbl_AccidentO = new HashSet<tbl_AccidentO>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه سازمان")]
        public int OrId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "شماره تماس")]
        public string OrTel { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "عنوان")]
        public string OrTitel { get; set; }

        [Display(Name = "آدرس")]
        public string OrAdress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentO> tbl_AccidentO { get; set; }
    }
}
