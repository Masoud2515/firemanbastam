namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tbl_GalleryImage")]
    public class GalleryImage
    {
        [Key]
        [Display(Name ="شناسه")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("GalleryImageId")]
        [Required(ErrorMessage = "شناسه وارد نشده است")]
        public int Id { get; set; }
       
        
        [Display(Name = "آدرس تصویر")]
        [Column("ImageUrl")]
        [MaxLength(255, ErrorMessage = "طول کارکتر های وارد شده بیشتر از حد مجاز است ")]
        public string ImageUrl { get; set; }

        [Column("IndexPic")]
        public bool IndexPic { get; set; }
        [Display(Name = "عکس شاخص")]

        #region ForeignKeygallery
        [Column("GalleryId")]
        [ForeignKey("gallery")]
        [Required]
        public int GalleryId { get; set; }
        public Gallery gallery { get; set; }
        #endregion


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
    }
}
