using System.ComponentModel.DataAnnotations;

namespace AdminPanelCore.ENTITIES.ComplexTypes
{
    public class CategoryDetail
    {
        public int Id { get; set; }

        [Display(Name="Kategori")]
        public string CategoryName { get; set; }

        [Display(Name = "AltKategori")]
        public string SubCategoryName { get; set; }

        public int SubCategoryID { get; set; }

        [Display(Name = "Kategori Tipi")]
        public string CategoryTypeName { get; set; }

        public int CategoryTypeID { get; set; }

        public string Title { get; set; }

        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "Meta Keywords")]
        public string MetaKeywords { get; set; }

        [Display(Name = "Aktif Mi")]
        public bool IsActive { get; set; }

        [Display(Name = "Görüntülensin Mi")]
        public bool IsDisplay { get; set; }

        [Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Seo Link")]
        public string SeoLink { get; set; }
    }
}
