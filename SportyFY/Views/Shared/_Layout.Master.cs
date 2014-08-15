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
            pnlAdmin.Visible = false;

            var role = Roles.GetRolesForUser()[0].ToLower().Trim();

            switch (role)
            {
                case "admin":
                    pnlAdmin.Visible = true;
                    break;
                case "superadmin":
                    //TODO
                    break;
                case "team":
                    //TODO
                    break;
                case "player":
                    //TODO
                    break;
                case "user":
                    //TODO
                    break;
                default:
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PrepareMenuBar();
            }
        }
    }
}