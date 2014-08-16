using SportyFY.EDM;
using SportyFY.EDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.BuisnessAccessLayer
{
    public class BAL_NewsSubCategoryMaster
    {
        public static List<NewsSubCategoryMaster> getNewsSubCategories(int categoryId)
        {
            List<NewsSubCategoryMaster> lst = EDM_NewsSubCategoryMaster.getNewsSubCategories(categoryId);

            if (lst.Count > 0)
            {
                return lst;
            }
            else
            {
                throw null;
            }
        }
    }
}
