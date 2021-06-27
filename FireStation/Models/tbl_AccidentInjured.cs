namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccidentInjured
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه مصدوم حادثه")]
        public int AccidentInjuredid { get; set; }

        [Display(Name = "شناسه حادثه")]
        public int AccidentId { get; set; }

        [Display(Name = "شناسه مصدوم")]
        public int InjuredId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_Injured tbl_Injured { get; set; }
    }
}
