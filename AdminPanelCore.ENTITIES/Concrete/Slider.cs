using CORE.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelCore.ENTITIES.Concrete
{
    public class Slider : AuditEntity
    {
        [Required, Display(Name = "Slider Başlık")]
        public string SliderTitle { get; set; }

        [Required, Display(Name = "Slider Açıklama")]
        public string SliderDescription { get; set; }

        [Required, Display(Name = "Slider Url")]
        public string SliderNewsUrl { get; set; }

        [Display(Name = "Slider By Resim (850x400px)")]
        public string SliderImageUrlLarge { get; set; }

        [Display(Name = "Slider Kç Resim (285x100px)")]
        public string SliderImageUrlSmall { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
    }
}