namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Tbl_Gallery")]
    public class Gallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        [Column("GalleryId")]
        [Required(ErrorMessage = "شناسه وارد نشده است")]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Column("GalleryName")]
        [Required(ErrorMessage ="نام گالری را وارد کنید")]
        [MaxLength(50, ErrorMessage = "طول کارکتر های وارد شده بیشتر از حد مجاز است ")]
        [Display(Name = "شناسه نام عکس")]
        public string Name { get; set; }


        //******************************
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "قالب تاریخ معتبر نیست")]
        [Column("DateCreate")]
        public DateTime DateCreate { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "قالب تاریخ معتبر نیست")]
        [Column("LastUpdate")]
        public DateTime LastUpdate { get; set; }
        [Required]
        [Column("IsDelete")]
        public bool IsDelete { get; set; }
        //********************************

        //public List<GalleryImage> galleryImages { get; set; }
        //public List<Product> products { get; set; }
        //public List<Blog>blogs { get; set; }
    }
}
