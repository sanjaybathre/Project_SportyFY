using SportyFY.EDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.EDM
{
    public class EDM_NewsTags
    {
        public static int SaveNewsTags(Guid newsID, string newsTag, Guid? userid)
        {
            using (SportyFYEntities model = new SportyFYEntities())
            {
                model.NewsTags.Add(new NewsTag
                {
                    NewsId = newsID,
                    TagKeywords = newsTag,
                    Userid = userid
                });

                return model.SaveChanges();
            }
        }
    }
}
