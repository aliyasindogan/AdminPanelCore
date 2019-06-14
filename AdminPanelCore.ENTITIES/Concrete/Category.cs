using AdminPanelCore.CORE.Entities.Abstarct;
using AdminPanelCore.CORE.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    [Table("Category")]
    public class Category : SoftDeleteEntity, ISeoEntity, IDisplayEntity
    {
        [Required, Display(Name = "Kategori")]
        public string CategoryName { get; set; }

        [Display(Name = "Alt Kategori")]
        public Nullable<int> SubCategoryID { get; set; }

        [Required, Display(Name = "Kategori Tipi")]
        public int CategoryTypeID { get; set; }

        /// <summary>
        /// Login veya veb sayfası için seçilmiş kategoriye göre ilk sayfa olarak bu sayfaya yönlendirilir. Örnek: Web için AnaSayfa admin için Dashboard gibi
        /// </summary>
        [Required, Display(Name = "Giriş Sayfası Mı?")]
        public bool IsHomePage { get; set; }

        [Required, Display(Name = "Seo Link")]
        public string SeoLink { get; set; }

        [Required, Display(Name = "Title (70)")]
        public string Title { get; set; }

        [Display(Name = "Meta Description (160)")]
        public string MetaDescription { get; set; }

        [Display(Name = "Meta Keywords (260)")]
        public string MetaKeywords { get; set; }

        [Required, Display(Name = "Görüntülensin Mi")]
        public bool IsDisplay { get; set; }

        [Required, Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }
    }
}