using AdminPanelCore.CORE.Entities.Abstarct;
using AdminPanelCore.CORE.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    [Table("Slider")]
    public class Slider : SoftDeleteEntity, IDisplayEntity
    {
        [Required, Display(Name = "Slider Başlık")]
        public string SliderTitle { get; set; }

        [Required, Display(Name = "Slider Açıklama")]
        public string SliderDescription { get; set; }

        [Required, Display(Name = "Slider Haber Url")]
        public string SliderNewsUrl { get; set; }

        [Display(Name = "Slider By Resim (850x400px)")]
        public string SliderImageUrlLarge { get; set; }

        [Display(Name = "Slider Kç Resim (285x100px)")]
        public string SliderImageUrlSmall { get; set; }

        [Required, Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }

        [Required, Display(Name = "Görüntülensin Mi?")]
        public bool IsDisplay { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
    }
}
