using SportyFY.EDM;
using SportyFY.EDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using SportyFY.Utility.Authentication;

namespace SportyFY.BuisnessAccessLayer
{
    public class BAL_NewsMaster
    {
        public static string SaveNews(ContentPlaceHolder _refContentPlaceHolder)
        {
            try
            {
                if (_refContentPlaceHolder.Controls.Count > 0)
                {
                    TextBox txt = null;
                    DropDownList ddl = null;
                    NewsMaster _NewsMaster = new NewsMaster();
                    List<string> lstTags = new List<string>();

                    Guid _newsID = Guid.NewGuid();

                    _NewsMaster.NewsId = _newsID;
                    _NewsMaster.IsDel = false;
                    _NewsMaster.Userid = RoleAuth.GetUserID();
                    _NewsMaster.NewsCreateDate = DateTime.Now;

                    for (int i = 0; i < _refContentPlaceHolder.Controls.Count; i++)
                    {
                        if (_refContentPlaceHolder.Controls[i] is DropDownList)
                        {
                            ddl = _refContentPlaceHolder.Controls[i] as DropDownList;

                            if (ddl.ClientID == "ddl_NewsCategory")
                            {
                                if (ddl.SelectedItem.Value == "-1")
                                {
                                    // validate the data and return message
                                    throw new Exception("there is no category selected!");
                                }
                                else
                                {
                                    // creating the NewsMaster data
                                    _NewsMaster.CategoryId = int.Parse(ddl.SelectedItem.Value.Trim());
                                }
                            }
                            else if (ddl.ClientID == "ddl_newsSubCategory")
                            {
                                ddl = _refContentPlaceHolder.Controls[i] as DropDownList;

                                if (ddl.SelectedItem.Value == "-1")
                                {
                                    // validate the data and return message
                                    throw new Exception("there is no sub category selected!");
                                }
                                else
                                {
                                    // creating the NewsMaster data
                                    _NewsMaster.SubCategoryId = int.Parse(ddl.SelectedItem.Value.Trim());
                                }
                            }
                        }
                        else if (_refContentPlaceHolder.Controls[i] is TextBox)
                        {
                            txt = _refContentPlaceHolder.Controls[i] as TextBox;

                            if (txt.ClientID == "txtTitle")
                            {
                                if (txt.Text == "")
                                {
                                    // validate the data and return message
                                    throw new Exception("please enter title!");
                                }
                                else
                                {
                                    // creating the NewsMaster data
                                    _NewsMaster.NewsTitle = txt.Text.Trim();
                                }
                            }
                            else if (txt.ClientID == "txtNewsDate")
                            {
                                if (txt.Text == "")
                                {
                                    // validate the data and return message
                                    throw new Exception("please select date!");
                                }
                                else
                                {
                                    // creating the NewsMaster data
                                    _NewsMaster.NewsDate = DateTime.Parse(txt.Text.Trim());
                                }
                            }
                            else if (txt.ClientID == "txtAuthor")
                            {
                                if (txt.Text == "")
                                {
                                    // validate the data and return message
                                    throw new Exception("please enter Author Name!");
                                }
                                else
                                {
                                    // creating the NewsMaster data
                                    _NewsMaster.NewsDate = DateTime.Parse(txt.Text.Trim());
                                }
                            }
                            else if (txt.ClientID == "txtContent")
                            {
                                if (txt.Text == "")
                                {
                                    // validate the data and return message
                                    throw new Exception("please enter news content!");
                                }
                                else
                                {
                                    // creating the NewsMaster data
                                    _NewsMaster.NewsContent = txt.Text;
                                }
                            }
                            else if (txt.ClientID == "txtTags")
                            {
                                if (txt.Text == "")
                                {
                                    // validate the data and return message
                                    lstTags = null;
                                }
                                else
                                {
                                    // creating the NewsMaster data
                                    lstTags.Add(txt.Text.Trim());
                                }
                            }
                        }
                    }

                    // Save into NewsMaster Table
                    int t = EDM_NewsMaster.SaveNews(_NewsMaster);
                    if (t > 0)
                    {
                        if (lstTags != null && lstTags.Count > 0)
                        {
                            for (int i = 0; i < lstTags.Count; i++)
                            {
                                t = BAL_NewsTags.SaveNewsTags(_newsID, lstTags[i].Trim());
                            }
                        }
                        else if (lstTags == null)
                        {
                            //TODO
                        }

                        return "Success";
                    }
                    else
                    {
                        return "Faliure";
                    }
                }
                else
                {
                    throw new Exception("Null Data");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
