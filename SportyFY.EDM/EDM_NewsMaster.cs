using SportyFY.EDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.EDM
{
    public class EDM_NewsMaster
    {
        public static int SaveNews(NewsMaster _NewsMaster)
        {
            using (SportyFYEntities model = new SportyFYEntities())
            {
                model.NewsMasters.Add(new NewsMaster
                {
                    NewsId = _NewsMaster.NewsId,
                    CategoryId = _NewsMaster.CategoryId,
                    SubCategoryId = _NewsMaster.SubCategoryId,
                    NewsTitle = _NewsMaster.NewsTitle,
                    NewsContent = _NewsMaster.NewsContent,
                    NewsAuthor = _NewsMaster.NewsAuthor,
                    NewsCreateDate = _NewsMaster.NewsCreateDate,
                    IsDel = _NewsMaster.IsDel,
                    Userid = _NewsMaster.Userid,
                    NewsDate = _NewsMaster.NewsDate
                });

                return model.SaveChanges();
            }            
        }
    }
}
