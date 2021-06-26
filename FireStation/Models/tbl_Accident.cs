namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Accident
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Accident()
        {
            tbl_AccidentEmplyoee = new HashSet<tbl_AccidentEmplyoee>();
            tbl_AccidentInjured = new HashSet<tbl_AccidentInjured>();
            tbl_AccidentM = new HashSet<tbl_AccidentM>();
            tbl_AccidentO = new HashSet<tbl_AccidentO>();
            tbl_AccidentStation = new HashSet<tbl_AccidentStation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccidentId { get; set; }

        [Required]
        public string AccidentEventLocation { get; set; }

        [Required]
        public string AccidentDescrption { get; set; }

        public TimeSpan AccidentTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime AccidentDate { get; set; }

        public string AccidentReportUrl { get; set; }

        public int AccidentWid { get; set; }

        public int AccidentTypeId { get; set; }

        public int AccidentZone { get; set; }

        public int AccidentUserId { get; set; }

        public int AccidentUsageId { get; set; }

        public TimeSpan AccidentTimeStartOperation { get; set; }

        public TimeSpan AccidentTimeEndOperation { get; set; }

        public TimeSpan? AccidentTimeToClear { get; set; }

        [Required]
        [StringLength(50)]
        public string AccidentReporter { get; set; }

        public int AccidentReportReciver { get; set; }

        public int AccidentReportType { get; set; }

        public int? AccidentSiteFloors { get; set; }

        [StringLength(50)]
        public string AccidentBuildingType { get; set; }

        [Required]
        [StringLength(50)]
        public string AccidentBuildingOwner { get; set; }

        [StringLength(15)]
        public string AccidentBuildingTel { get; set; }

        [StringLength(50)]
        public string AccidentBuildingTenant { get; set; }

        public string AccidentOtherType { get; set; }

        public string AccidentPreliminaryMeasures { get; set; }

        public string AccidentDescriptionOperation { get; set; }

        public string AccidentDamageDescriptionO { get; set; }

        public string AccidentDamageDescriptionL { get; set; }

        public int AccidentReportProducer { get; set; }

        public int AccidentOperationsCommander { get; set; }

        public DateTime DateAdd { get; set; }

        public string AccidentOperationProblems { get; set; }

        public int AccidentCause { get; set; }

        public bool Isdelete { get; set; }

        public virtual tbl_AccidentType tbl_AccidentType { get; set; }

        public virtual tbl_Cause tbl_Cause { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }

        public virtual tbl_Employee tbl_Employee1 { get; set; }

        public virtual tbl_Usage tbl_Usage { get; set; }

        public virtual tbl_weather tbl_weather { get; set; }

        public virtual tbl_User tbl_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentEmplyoee> tbl_AccidentEmplyoee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentInjured> tbl_AccidentInjured { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentM> tbl_AccidentM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentO> tbl_AccidentO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccidentStation> tbl_AccidentStation { get; set; }
    }
}
