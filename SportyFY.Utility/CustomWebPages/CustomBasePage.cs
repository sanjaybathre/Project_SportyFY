using SportyFY.Utility.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.Utility.CustomWebPages
{
    public class CustomBasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (RoleAuth.CheckLoggedInUserSession(RoleAuth.UserRoles.Admin) ||
               RoleAuth.CheckLoggedInUserSession(RoleAuth.UserRoles.Player) ||
               RoleAuth.CheckLoggedInUserSession(RoleAuth.UserRoles.SuperAdmin) ||
              RoleAuth.CheckLoggedInUserSession(RoleAuth.UserRoles.Team) ||
               RoleAuth.CheckLoggedInUserSession(RoleAuth.UserRoles.User))
            {
                //TODO
            }
            else
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Views/Authentication/Login");
            }

            // Be sure to call the base class's OnLoad method!
            base.OnLoad(e);
        }
    }
}
