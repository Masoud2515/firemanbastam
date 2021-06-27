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
        [Display(Name = "شماره حادثه")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccidentId { get; set; }

        [Required]
        [Display(Name = "آدرس محل حادثه")]
        public string AccidentEventLocation { get; set; }

        [Required]
        [Display(Name = "توضیح علت")]
        public string AccidentDescrption { get; set; }

        [Display(Name = "زمان اعلام")]
        public TimeSpan AccidentTime { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاریخ حادثه")]
        public DateTime AccidentDate { get; set; }

        [Display(Name = "فایل اسکن شده گزارش")]
        public string AccidentReportUrl { get; set; }

        [Display(Name = "شرایط جوی")]
        public int AccidentWid { get; set; }

        [Display(Name = "نوع حادثه")]
        public int AccidentTypeId { get; set; }

        [Display(Name = "منطقه حادثه")]
        public int AccidentZone { get; set; }

        [Display(Name = "کاربر ثبت کننده حادثه")]
        public int AccidentUserId { get; set; }

        [Display(Name = "مورد کاربری")]
        public int AccidentUsageId { get; set; }

        [Display(Name = "زمان شروع حادثه")]
        public TimeSpan AccidentTimeStartOperation { get; set; }

        [Display(Name = "زمان اتمام حادثه")]
        public TimeSpan AccidentTimeEndOperation { get; set; }

        [Display(Name = "زمان پاکسازی")]
        public TimeSpan? AccidentTimeToClear { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "خبر دهنده")]
        public string AccidentReporter { get; set; }

        [Display(Name = "گیرنده خبر")]
        public int AccidentReportReciver { get; set; }

        [Display(Name = "روش خبررسانی")]
        public int AccidentReportType { get; set; }

        [Display(Name = "تعداد طبقات")]
        public int? AccidentSiteFloors { get; set; }

        [StringLength(50)]
        [Display(Name = "نوع ساختمان")]
        public string AccidentBuildingType { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "مالک")]
        public string AccidentBuildingOwner { get; set; }

        [StringLength(15)]
        [Display(Name = "شماره تلفن")]
        public string AccidentBuildingTel { get; set; }

        [StringLength(50)]
        [Display(Name = "مستاجر")]
        public string AccidentBuildingTenant { get; set; }

        [Display(Name = "نوع سایر حادثه")]
        public string AccidentOtherType { get; set; }

        [Display(Name = "اقدامات اولیه")]
        public string AccidentPreliminaryMeasures { get; set; }

        [Display(Name = "شرح عملیات")]
        public string AccidentDescriptionOperation { get; set; }

        [Display(Name = "خسارات وارده به محل حادثه")]
        public string AccidentDamageDescriptionO { get; set; }

        [Display(Name = "خسارت وارده به تجهیزات")]
        public string AccidentDamageDescriptionL { get; set; }

        [Display(Name = "تهیه کننده گزارش")]
        public int AccidentReportProducer { get; set; }

        [Display(Name = "فرمانده عملیات")]
        public int AccidentOperationsCommander { get; set; }

        public DateTime DateAdd { get; set; }

        [Display(Name = "شرح مشکلات")]
        public string AccidentOperationProblems { get; set; }

        [Display(Name = "علت حادثه")]
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
