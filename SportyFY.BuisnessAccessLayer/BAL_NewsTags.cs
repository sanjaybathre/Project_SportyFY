using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportyFY.EDM;
using SportyFY.Utility.Authentication;

namespace SportyFY.BuisnessAccessLayer
{
    public class BAL_NewsTags
    {
        public static int SaveNewsTags(Guid newsID, string newsTag)
        {
            int t = EDM_NewsTags.SaveNewsTags(newsID, newsTag, RoleAuth.GetUserID());
            return t;
        }
    }
}
