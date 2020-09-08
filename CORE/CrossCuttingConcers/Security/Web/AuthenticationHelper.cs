using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace AdminPanelCore.CORE.CrossCuttingConcers.Security.Web
{
    public class AuthenticationHelper
    {
        /// <summary>
        /// Cookie Oluşturma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="expiration"></param>
        /// <param name="roles"></param>
        /// <param name="rememberMe"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public static void CreateAuthCookie(Guid id, string userName, string email, DateTime expiration, string[] roles,
            bool rememberMe, string firstName, string lastName)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe,
                CreateAuthTags(email, roles, firstName, lastName, id));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i < roles.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            return stringBuilder.ToString();
        }
    }
}