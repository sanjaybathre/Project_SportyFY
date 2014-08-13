using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SportyFY.Utility.SessionManager
{
    public class UserSession
    {
        private const string SESSION_FirstName = "FirstName";
        private const string SESSION_LastName = "LastName";
        private const string SESSION_Email = "Email";
        
        public static string FirstName
        {
            get
            {
                if (null != HttpContext.Current.Session[SESSION_FirstName])
                    return HttpContext.Current.Session[SESSION_FirstName] as string;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[SESSION_FirstName] = value;
            }
        }

        public static string LastName
        {
            get
            {
                if (null != HttpContext.Current.Session[SESSION_LastName])
                    return HttpContext.Current.Session[SESSION_LastName] as string;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[SESSION_LastName] = value;
            }
        }

        public static string Email
        {
            get
            {
                if (null != HttpContext.Current.Session[SESSION_Email])
                    return HttpContext.Current.Session[SESSION_Email] as string;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[SESSION_Email] = value;
            }
        }

        public static bool HaveValues()
        {
            if (UserSession.FirstName != null && UserSession.LastName != null && UserSession.Email != null)
                return true;
            else
                return false;
        }
    }
}
