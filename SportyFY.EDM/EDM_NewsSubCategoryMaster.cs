using SportyFY.EDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.EDM
{
    public class EDM_NewsSubCategoryMaster
    {
        public static List<NewsSubCategoryMaster> getNewsSubCategories(int categoryId)
        {
            using (SportyFYEntities model = new SportyFYEntities())
            {
                var data = (from a in model.NewsSubCategoryMasters
                            where a.CategoryId == categoryId && a.IsDel != true
                            select a).ToList();
                return data;
            }
        }
    }
}
