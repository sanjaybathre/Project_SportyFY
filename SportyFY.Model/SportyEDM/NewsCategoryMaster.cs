//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportyFY.Model.SportyEDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewsCategoryMaster
    {
        public NewsCategoryMaster()
        {
            this.NewsSubCategoryMasters = new HashSet<NewsSubCategoryMaster>();
        }
    
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public Nullable<bool> IsDel { get; set; }
    
        public virtual ICollection<NewsSubCategoryMaster> NewsSubCategoryMasters { get; set; }
    }
}
