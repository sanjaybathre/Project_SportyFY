using SportyFY.EDM.Model;
using SportyFY.Utility.Helpers.CacheManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SportyFY.Utility.Helpers
{
    public class redirection
    {
        private static ICacheProvider Cache { get; set; }

        //used to send logged in user to their directory.....
        public static void GoHome(string username = null, bool termination = true)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    username = HttpContext.Current.User.Identity.Name.Trim();
                }

                Cache = new DefaultCacheProvider();

                //cache the user role for future use....
                if (!Cache.IsSet(SportyConstants.UserRolesCached))
                {
                    using (SportyFYEntities model = new SportyFYEntities())
                    {
                        //get all the roles from the DB
                        var qry = (from tmp in model.aspnet_Roles
                                   select tmp).ToList();

                        //cached for 24 hour.....
                        Cache.Set(SportyConstants.UserRolesCached, qry, 86400);

                        foreach (var item in qry)
                        {
                            //check logged in user role.....
                            if (Roles.IsUserInRole(username, item.RoleName))
                            {
                                HttpContext.Current.Response.Redirect("~/Views/Common/Home", termination);
                            }
                        }
                        HttpContext.Current.Session.RemoveAll();
                        HttpContext.Current.Session.Abandon();
                        System.Web.Security.FormsAuthentication.SignOut();
                        System.Web.Security.FormsAuthentication.RedirectToLoginPage();
                    }
                }
                else
                {
                    var roles = Cache.Get(SportyConstants.UserRolesCached) as List<aspnet_Roles>;
                    foreach (var item in roles)
                    {
                        //check logged in user role.....
                        if (Roles.IsUserInRole(username, item.RoleName))
                        {
                            HttpContext.Current.Response.Redirect("~/Views/Common/Home", termination);
                        }
                    }
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Session.Abandon();
                    System.Web.Security.FormsAuthentication.SignOut();
                    System.Web.Security.FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                //don't log this.....
                //comes due to redirection in between of page execution.....
            }
        }
    }
}