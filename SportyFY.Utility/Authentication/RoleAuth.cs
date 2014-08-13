using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SportyFY.Utility.Authentication
{
    public class RoleAuth
    {
        public enum UserRoles { Admin, Player, SuperAdmin, Team, User }

        public static bool CheckLoggedInUserSession(UserRoles rolename)
        {
            bool ans = false;

            if (SessionManager.UserSession.HaveValues())
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.IsInRole(rolename.ToString()))
                    {
                        ans = true;
                    }
                }
            }
            return ans;
        }

        public static Guid? GetUserID()
        {
            string userid = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                userid = System.Web.Security.Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString().Trim();
            }
            return Guid.Parse(userid);
        }
    }
}
