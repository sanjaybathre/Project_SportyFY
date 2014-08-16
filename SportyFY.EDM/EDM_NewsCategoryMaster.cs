using SportyFY.EDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.EDM
{
    public class EDM_NewsCategoryMaster
    {
        public static List<NewsCategoryMaster> getNewsCategories()
        {
            using (SportyFYEntities model = new SportyFYEntities())
            {
                var data = (from a in model.NewsCategoryMasters
                            where a.IsDel != true
                            select a).ToList();
                return data;
            }            
        }
    }
}
