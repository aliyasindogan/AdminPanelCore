using CORE.Entities.Concrete;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace AdminPanelCore.CORE.Tools
{
    /// <summary>
    /// Upload edilen resimleri boyutlandırma
    /// </summary>
    public static class ImageResize
    {
        //SingleImageRizeUpload
        /// <summary>
        /// Resmi Büyük orta küçük olarak boyutlandırıyor.
        /// </summary>
        /// <param name="fuResim">FileUpload dan gelen resim</param>
        /// <param name="imageSize"> Resim boyutları</param>
        /// <returns></returns>
        public static string MultiImageResizeUpload(FileUpload fuResim, ImageSize imageSize)
        {
            try
            {
                string imageName = "";
                string extension = "";
                if (fuResim.HasFile)
                {
                    #region buyukresim

                    extension = Path.GetExtension(fuResim.PostedFile.FileName);
                    //resimadi = fuResim.FileName;
                    imageName = Guid.NewGuid().ToString() + extension; ;
                    fuResim.SaveAs(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy" + extension));
                    fuResim.SaveAs(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy1" + extension));
                    fuResim.SaveAs(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy2" + extension));
                    int Donusturme = 800;
                    Bitmap bmp = new Bitmap(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy" + extension));
                    Bitmap bmp1 = new Bitmap(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy1" + extension));
                    Bitmap bmp2 = new Bitmap(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy2" + extension));
                    using (Bitmap OrjinalImage = bmp)
                    {
                        double ResYukseklik = OrjinalImage.Height;
                        double ResGenislik = OrjinalImage.Width;
                        double oran = 0;

                        if (ResGenislik >= Donusturme || ResGenislik >= 500)
                        {
                            oran = ResGenislik / ResYukseklik;
                            ResGenislik = imageSize.LargeImageWidth;
                            ResYukseklik = imageSize.LargeImageHeight;
                            Size newValues = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                            Bitmap yeniresim = new Bitmap(OrjinalImage, newValues);
                            yeniresim.Save(HttpContext.Current.Server.MapPath(ConstantParameter.LargeImageFilePath + imageName));
                            yeniresim.Dispose();
                            OrjinalImage.Dispose();
                            bmp.Dispose();
                        }
                        else
                        {
                            fuResim.SaveAs(HttpContext.Current.Server.MapPath(ConstantParameter.LargeImageFilePath + imageName));
                        }
                    }

                    #endregion buyukresim

                    #region küçükresim

                    int Donusturme1 = 100;
                    using (Bitmap OrjinalResim1 = bmp1)
                    {
                        double ResYukseklik1 = OrjinalResim1.Height;
                        double ResGenislik1 = OrjinalResim1.Width;
                        double oran1 = 0;

                        if (ResGenislik1 != Donusturme1 || ResGenislik1 != 100)
                        {
                            oran1 = ResGenislik1 / ResYukseklik1;
                            ResGenislik1 = imageSize.MiddleImageWidth;
                            ResYukseklik1 = imageSize.MiddleImageHeight;

                            Size yenidegerler1 = new Size(Convert.ToInt32(ResGenislik1), Convert.ToInt32(ResYukseklik1));

                            Bitmap yeniresim1 = new Bitmap(OrjinalResim1, yenidegerler1);
                            yeniresim1.Save(HttpContext.Current.Server.MapPath(ConstantParameter.SmallImageFilePath + imageName));

                            yeniresim1.Dispose();
                            OrjinalResim1.Dispose();
                            bmp1.Dispose();
                        }
                        else
                        {
                            fuResim.SaveAs(HttpContext.Current.Server.MapPath(ConstantParameter.SmallImageFilePath + imageName));
                        }
                    }

                    #endregion küçükresim

                    #region ortaresim

                    int Donusturme2 = 400;
                    using (Bitmap OrjinalResim2 = bmp2)
                    {
                        double ResYukseklik2 = OrjinalResim2.Height;
                        double ResGenislik2 = OrjinalResim2.Width;
                        double oran2 = 0;

                        if (ResGenislik2 != Donusturme2 || ResGenislik2 != 300)
                        {
                            oran2 = ResGenislik2 / ResYukseklik2;
                            ResGenislik2 = imageSize.SmallImageWidth;
                            ResYukseklik2 = imageSize.SmallImageHeight;

                            Size yenidegerler2 = new Size(Convert.ToInt32(ResGenislik2), Convert.ToInt32(ResYukseklik2));

                            Bitmap yeniresim2 = new Bitmap(OrjinalResim2, yenidegerler2);
                            yeniresim2.Save(HttpContext.Current.Server.MapPath(ConstantParameter.MiddleImageFilePath + imageName));

                            yeniresim2.Dispose();
                            OrjinalResim2.Dispose();
                            bmp2.Dispose();
                        }
                        else
                        {
                            fuResim.SaveAs(HttpContext.Current.Server.MapPath(ConstantParameter.MiddleImageFilePath + imageName));
                        }

                        #endregion ortaresim
                    }
                }//if has.file son
                return imageName;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Tek Resim boyutlandırma yapılmaktadır.
        /// </summary>
        /// <param name="fuResim">FileUpload dan gelen resim</param>
        /// <param name="imageSize"> Büyük Resim boyutu giriş yapılmalı</param>
        /// <returns></returns>
        public static string SingleImageRizeUpload(FileUpload fuResim, ImageSize imageSizeLarge)
        {
            try
            {
                string imageName = "";
                string extension = "";
                if (fuResim.HasFile)
                {
                    extension = Path.GetExtension(fuResim.PostedFile.FileName);
                    //resimadi = fuResim.FileName;
                    imageName = Guid.NewGuid().ToString() + extension; ;
                    fuResim.SaveAs(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy" + extension));
                    Bitmap bmp = new Bitmap(HttpContext.Current.Server.MapPath(ConstantParameter.MainImageFilePath + "copy" + extension));

                    using (Bitmap OrjinalImage = bmp)
                    {
                        double ResYukseklik = OrjinalImage.Height;
                        double ResGenislik = OrjinalImage.Width;
                        ResGenislik = imageSizeLarge.LargeImageWidth;
                        ResYukseklik = imageSizeLarge.LargeImageHeight;
                        Size newValues = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                        Bitmap newImage = new Bitmap(OrjinalImage, newValues);
                        newImage.Save(HttpContext.Current.Server.MapPath(ConstantParameter.LargeImageFilePath + imageName));
                        newImage.Dispose();
                        OrjinalImage.Dispose();
                        bmp.Dispose();
                    }
                    return imageName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        //ResizeImage(400, File1.FileContent, path);
        public static void ResizeStream(int imageSize, Stream filePath, string outputPath)
        {
            var image = System.Drawing.Image.FromStream(filePath);

            int thumbnailSize = imageSize;
            int newWidth, newHeight;

            if (image.Width > image.Height)
            {
                newWidth = thumbnailSize;
                newHeight = image.Height * thumbnailSize / image.Width;
            }
            else
            {
                newWidth = image.Width * thumbnailSize / image.Height;
                newHeight = thumbnailSize;
            }

            var thumbnailBitmap = new Bitmap(newWidth, newHeight);

            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbnailGraph.DrawImage(image, imageRectangle);

            thumbnailBitmap.Save(outputPath, image.RawFormat);
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();
        }
    }
}