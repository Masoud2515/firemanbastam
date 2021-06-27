namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Material()
        {
            tbl_AccidentM = new HashSet<tbl_AccidentM>();
            tbl_Repair = new HashSet<tbl_Repair>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه تجهیزات")]
        public int MaterialId { get; set; }

        [StringLength(15)]
        [Display(Name = "شماره اموال")]
        public string MaterialCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "نام")]
        public string MaterialName { get; set; }

        [Required]
        [Display(Name = "تصویر")]
        public string MaterialPic { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "نوع تجهیز")]
        public string MaterialType { get; set; }

        [StringLength(15)]
        [Display(Name = "واحد شمارش")]
        public string MaterialVahed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentM> tbl_AccidentM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Repair> tbl_Repair { get; set; }
    }
}
