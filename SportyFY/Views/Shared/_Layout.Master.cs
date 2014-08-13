using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportyFY.Views.Shared
{
    public partial class _Layout : System.Web.UI.MasterPage
    {
        protected void PrepareMenuBar()
        {
            var role = Roles.GetRolesForUser()[0].ToLower().Trim();

            switch (role)
            {
                case "Admin":
                    //TODO
                    break;
                case "SuperAdmin":
                    //TODO
                    break;
                case "Team":
                    //TODO
                    break;
                case "Player":
                    //TODO
                    break;
                case "User":
                    //TODO
                    break;
                default:
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}