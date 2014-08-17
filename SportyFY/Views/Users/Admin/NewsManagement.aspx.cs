using AjaxControlToolkit;
using SportyFY.Utility.CustomWebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportyFY.EDM;
using SportyFY.BuisnessAccessLayer;
using SportyFY.Utility.Authentication;
using SportyFY.Utility.SessionManager;

namespace SportyFY.Views.Users.Admin
{
    public partial class NewsManagement : AdminBasePage
    {
        static string category = "";
        static string subcategory = "";

        // loading news category
        public void loadNewsCategories()
        {
            try
            {
                ddl_NewsCategory.DataSource = BAL_NewsCategoryMaster.getNewsCategories();
                ddl_NewsCategory.DataTextField = "Category";
                ddl_NewsCategory.DataValueField = "CategoryId";
                ddl_NewsCategory.DataBind();
            }
            catch (Exception)
            {
                ddl_NewsCategory.Items.Clear();
                ddl_NewsCategory.Items.Insert(0, new ListItem("No Categories Loaded", "-1"));
            }
        }

        // loading news subcategory
        public void loadNewsSubCategories(int categoryId)
        {
            try
            {
                ddl_newsSubCategory.DataSource = BAL_NewsSubCategoryMaster.getNewsSubCategories(categoryId);
                ddl_newsSubCategory.DataTextField = "SubCategory";
                ddl_newsSubCategory.DataValueField = "SubCategoryId";
                ddl_newsSubCategory.DataBind();
            }
            catch (Exception ex)
            {
                ddl_newsSubCategory.Items.Clear();
                ddl_newsSubCategory.Items.Insert(0, new ListItem("No SubCategories Loaded", "-1"));
            }           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HtmlEditorExtenderContent.AjaxFileUpload.IsInFileUploadPostBack)
            {
                // TODO
            }
            else if (!Page.IsPostBack)
            {
                // setting the file restriction
                var ajaxFileUpload = HtmlEditorExtenderContent.AjaxFileUpload;
                ajaxFileUpload.AllowedFileTypes = "jpg,jpeg,gif,png";

                txtContent.Text = Resources.CommonMessages.NewsContentConstant;
                loadNewsCategories();
                loadNewsSubCategories(int.Parse(ddl_NewsCategory.SelectedItem.Value));
            }
            else if (Page.IsPostBack)
            {
                category = "";
                subcategory = "";

                category = ddl_NewsCategory.SelectedItem.Text;
                subcategory = ddl_newsSubCategory.SelectedItem.Text;
            }
        }

        protected void HtmlEditorExtenderContent_ImageUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string fileName = DateTime.Now.ToString("MMM-ddd-d-HH-mm-ss-yyyy") + "_" + e.FileName;

            string subpath = Server.MapPath("~/StoryImages/") + subcategory.Trim();

            //if not the create user directory
            if (!System.IO.Directory.Exists(subpath))
            {
                System.IO.Directory.CreateDirectory(subpath);
                
                // Create the path and file name to check for duplicates.
                string filepath = subpath + "\\" + fileName;

                HtmlEditorExtenderContent.AjaxFileUpload.SaveAs(filepath);

                e.PostedUrl = Page.ResolveUrl(subpath + "\\" + fileName);
            }
            else
            {
                // Create the path and file name to check for duplicates.
                string filepath = subpath + "\\" + fileName;

                HtmlEditorExtenderContent.AjaxFileUpload.SaveAs(filepath);

                e.PostedUrl = Page.ResolveUrl(subpath + "\\" + fileName);
            }

            //// Generate file path
            //string filePath = CreateaUserDirectory(e.FileName);

            //// Save uploaded file to the file system
            //var ajaxFileUpload = (AjaxFileUpload)sender;
            //ajaxFileUpload.SaveAs(MapPath(filePath));

            // Update client with saved image path
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string te = txtContent.Text;

                foreach (var item in this.Form.Controls)
                {
                    if (item is ContentPlaceHolder)
                    {
                        ContentPlaceHolder cp_Body = item as ContentPlaceHolder;

                        if (cp_Body.ClientID == "ContentPlaceHolder_Body")
                        {
                            BAL_NewsMaster.SaveNews(cp_Body);
                        }                        
                    }
                }

                var t = this.Form.Controls;
            }
            catch (Exception ex)
            {
                litMsg.Text = ex.Message;
            }
        }

        protected void ddl_NewsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadNewsSubCategories(int.Parse(ddl_NewsCategory.SelectedItem.Value));
            }
            catch (Exception ex)
            {

            }
        }
        
    }
}