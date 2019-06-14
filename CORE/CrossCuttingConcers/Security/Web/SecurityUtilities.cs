using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace AdminPanelCore.CORE.CrossCuttingConcers.Security.Web
{
    public class SecurityUtilities
    {
        /// <summary>
        /// FormsAuthentication (Cookie) ını  Identity e dönüştürüyoruz.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = SetId(ticket),
                Name = SetName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated()
            };
            return identity;
        }

        private bool SetIsAuthenticated()
        {
            return true;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            //CreateAuthTags(email [0], roles [1], firstName [2], lastName [3], id [4]));
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            //CreateAuthTags(email [0], roles [1], firstName [2], lastName [3], id [4]));
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            //CreateAuthTags(email [0], roles [1], firstName [2], lastName [3], id [4]));
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            //CreateAuthTags(email [0], roles [1], firstName [2], lastName [3], id [4]));
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            //CreateAuthTags(email [0], roles [1], firstName [2], lastName [3], id [4]));
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
