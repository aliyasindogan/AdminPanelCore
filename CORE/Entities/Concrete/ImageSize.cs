namespace AdminPanelCore.CORE.Entities.Concrete
{
    /// <summary>
    /// Resim Boyutları
    /// </summary>
    public class ImageSize
    {
        /// <summary>
        /// Büyük Resim Yüksekliği
        /// </summary>
        public double LargeImageHeight { get; set; }
        /// <summary>
        /// Büyük Resim Genişliği
        /// </summary>
        public double LargeImageWidth { get; set; }
        /// <summary>
        ///  Orta Resim Yüksekliği
        /// </summary>
        public double MiddleImageHeight { get; set; }
        /// <summary>
        /// Orta Resim Genişliği
        /// </summary>
        public double MiddleImageWidth { get; set; }
        /// <summary>
        ///  Küçük Resim Yüksekliği
        /// </summary>
        public double SmallImageHeight { get; set; }
        /// <summary>
        /// Küçük Resim Genişliği
        /// </summary>
        public double SmallImageWidth { get; set; }
    }
}
