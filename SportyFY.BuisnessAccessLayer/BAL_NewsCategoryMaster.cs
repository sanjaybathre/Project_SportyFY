using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportyFY.EDM.Model;
using SportyFY.EDM;

namespace SportyFY.BuisnessAccessLayer
{
    public class BAL_NewsCategoryMaster
    {
        public static List<NewsCategoryMaster> getNewsCategories()
        {
            List<NewsCategoryMaster> lst = EDM_NewsCategoryMaster.getNewsCategories();

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
