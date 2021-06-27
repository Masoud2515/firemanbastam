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
        [Display(Name = "شناسه مصدوم")]
        public int InjuredID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "نام مصدوم")]
        public string InjuredName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "نام خانوادگی")]
        public string InjuredLastName { get; set; }

        [Display(Name = "جنسیت")]
        public bool InjuredSex { get; set; }

        [Display(Name = "مأمور / غیر مأمور")]
        public bool InjuredType { get; set; }

        [Display(Name = "نوع مصدومیت")]
        public bool InjuredTypeinjury { get; set; }

        [Required]
        [Display(Name = "شرح مصدومیت")]
        public string InjuredDescription { get; set; }

        [Display(Name = "محل اعزام")]
        public string InjuredLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentInjured> tbl_AccidentInjured { get; set; }
    }
}
