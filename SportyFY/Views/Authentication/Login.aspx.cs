using SportyFY.DataAccessLayer.SqlServer.SqlHelper;
using SportyFY.EDM.Model;
using SportyFY.Utility.Helpers;
using SportyFY.Utility.Helpers.Message;
using SportyFY.Utility.SessionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportyFY.Views.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        private Sql _sql = new Sql();

        protected void Page_Load(object sender, EventArgs e)
        {
            //redirect if user signed in
            if (Session.Count > 0 && UserSession.HaveValues())
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    redirection.GoHome();
                }
                else
                {
                    Session.RemoveAll();
                    Session.Abandon();
                    System.Web.Security.FormsAuthentication.SignOut();
                    System.Web.Security.FormsAuthentication.RedirectToLoginPage();
                }
            }
            //logout if session is null
            else if (Session.Count > 0 && !UserSession.HaveValues())
            {
                Session.RemoveAll();
                Session.Abandon();
                System.Web.Security.FormsAuthentication.SignOut();
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }
            //logout if session server restarted
            else if (Session.Count == 0 && this.Page.User.Identity.IsAuthenticated)
            {
                Session.RemoveAll();
                Session.Abandon();
                System.Web.Security.FormsAuthentication.SignOut();
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }

            if (!Page.IsPostBack)
            {
                Response.Expires = -1;
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");
            }
        }

        public void setSession(string uname)
        {
            MembershipUser LoginUser = Membership.GetUser(uname);
            object obj = LoginUser.ProviderUserKey;

            DataSet qryData = _sql.getLoggingInUserdetails((Guid)obj);

            if (qryData != null && qryData.Tables.Count > 0 && qryData.Tables[0].Rows.Count > 0)
            {
                //add the personal info....
                UserSession.FirstName = qryData.Tables[0].Rows[0]["firstname"].ToString();
                UserSession.LastName = qryData.Tables[0].Rows[0]["lastname"].ToString();
                UserSession.Email = qryData.Tables[0].Rows[0]["email"].ToString();
            }
            else
            {
                Response.Redirect("~/views/login/login", true);
            }
        }

        protected void LoginSporty_LoggedIn(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Login log = LoginSporty;

                setSession(log.UserName);

                redirection.GoHome(log.UserName);
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                //don't log this.....
                //comes due to redirection in between of page execution.....
            }
        }

        protected void LoginSporty_LoginError(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Login log = LoginSporty;
            MembershipUser userInfo = Membership.GetUser(log.UserName);

            if (userInfo == null)
            {
                log.FailureText = CommonMessages.ShowMsg_Literal("There is no user in the database with the username " + log.UserName + ".", CommonMessages.messageType.ERROR);
            }
            else
            {
                if (!userInfo.IsApproved)
                {
                    log.FailureText = CommonMessages.ShowMsg_Literal("Your account has not yet been approved. Please try again later...", CommonMessages.messageType.WARNING);
                }
                else if (userInfo.IsLockedOut)
                {
                    SportyFYEntities model = new SportyFYEntities();
                    string status = "";

                    var qry = from a in model.UserMasters
                              where a.UserId == (Guid)userInfo.ProviderUserKey
                              select a;

                    foreach (var t in qry)
                    {
                        status = t.status.ToUpper();
                        if (status.ToUpper() == "U")
                        {
                            log.FailureText = CommonMessages.ShowMsg_Literal("Your account is temporary locked for security reasons...", CommonMessages.messageType.WARNING);

                            string time = ConfigurationManager.AppSettings["autoUnlockTimeout"];
                            if (!String.IsNullOrEmpty(time))
                            {
                                if (userInfo.LastLockoutDate.ToUniversalTime().AddMinutes(Double.Parse(time)) < DateTime.UtcNow)
                                {
                                    bool retval = userInfo.UnlockUser();
                                    if (retval)
                                        Membership.UpdateUser(userInfo);
                                }
                                else
                                {
                                    //send mail to unlock it now.....
                                }
                            }
                        }
                        else if (status.ToUpper() == "D")
                        {
                            log.FailureText = CommonMessages.ShowMsg_Literal("Your account has been deleted by the Admin due to some reasons...", CommonMessages.messageType.ERROR);
                        }
                        else if (status.ToUpper() == "L")
                        {
                            log.FailureText = CommonMessages.ShowMsg_Literal("Your account has been locked out by the Admin due to some reasons...", CommonMessages.messageType.ERROR);
                        }
                        else
                        {
                            log.FailureText = CommonMessages.ShowMsg_Literal("Your account details has not been authenticated...", CommonMessages.messageType.ERROR);
                        }
                    }
                }
                else
                {
                    log.FailureText = CommonMessages.ShowMsg_Literal("Username or password not match...", CommonMessages.messageType.ERROR);
                }
            }
        }
    }
}