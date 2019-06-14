using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelCore.CORE.Tools
{
  public static class SeoLink
    {
       /// <summary>
       /// Linki Seo ye uyumlu hale getiriyor
       /// </summary>
       /// <param name="keyword">Url</param>
       /// <returns></returns>
        public static string SeoFrendlyLink(string keyword)
        {
            string newKeyword = keyword.ToString();
            //newKeyword = newKeyword.ToLower();//stringi küçük harfli hale getiriyoruz.
            newKeyword = newKeyword.Replace("ü", "u");
            newKeyword = newKeyword.Replace("ğ", "g");
            newKeyword = newKeyword.Replace("ö", "o");
            newKeyword = newKeyword.Replace("ş", "s");
            newKeyword = newKeyword.Replace("ç", "c");
            newKeyword = newKeyword.Replace("ı", "i");
            newKeyword = newKeyword.Replace("!", "");
            newKeyword = newKeyword.Replace("?", "");
            newKeyword = newKeyword.Replace(".", "-");
            newKeyword = newKeyword.Replace(",", "");
            newKeyword = newKeyword.Replace("!", "");
            newKeyword = newKeyword.Replace("'", "-");
            newKeyword = newKeyword.Replace("#", "sharp");
            newKeyword = newKeyword.Replace(";", "");
            newKeyword = newKeyword.Replace(")", "");
            newKeyword = newKeyword.Replace("[", "");
            newKeyword = newKeyword.Replace("]", "");
            newKeyword = newKeyword.Replace("(", "");
            newKeyword = newKeyword.Replace(" ", "-");
            newKeyword = newKeyword.Replace("--", "-");
            newKeyword = newKeyword.Replace("---", "-");
            newKeyword = newKeyword.Replace("----", "-");
            newKeyword = newKeyword.Replace("/", "-");
            newKeyword = newKeyword.Replace(":", "-");
            newKeyword = newKeyword.Replace("%", "yuzde");
            return newKeyword;
        }
    }
}
