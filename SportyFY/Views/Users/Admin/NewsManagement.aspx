<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="NewsManagement.aspx.cs" Inherits="SportyFY.Views.Users.Admin.NewsManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            if (Sys.Extended && Sys.Extended.UI && Sys.Extended.UI.HtmlEditorExtenderBehavior && Sys.Extended.UI.HtmlEditorExtenderBehavior.prototype
            && Sys.Extended.UI.HtmlEditorExtenderBehavior.prototype._editableDiv_submit) {
                Sys.Extended.UI.HtmlEditorExtenderBehavior.prototype._editableDiv_submit = function () {
                    //html encode
                    var char = 3;
                    var sel = null;
                    alert(1);
                    setTimeout(function () {
                        if (this._editableDiv != null)
                            this._editableDiv.focus();
                    }, 0);
                    if (Sys.Browser.agent != Sys.Browser.Firefox) {
                        if (document.selection) {
                            sel = document.selection.createRange();
                            sel.moveStart('character', char);
                            sel.select();
                            alert(2);
                        }
                        else {
                            if (this._editableDiv.firstChild != null && this._editableDiv.firstChild != undefined) {
                                alert(3);
                                sel = window.getSelection();
                                sel.collapse(this._editableDiv.firstChild, char);
                            }
                        }
                    }

                    //Encode html tags
                    this._textbox._element.value = this._encodeHtml();
                }
            }
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <asp:UpdateProgress ID="uprogresNews" runat="server">
        <ProgressTemplate>
            <b>loading</b>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="upNews" runat="server">
        <ContentTemplate>

            <table style="width:100%;">
                <tr>
                    <td>Select Category</td>
                    <td>
                        <asp:DropDownList ID="ddl_NewsCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_NewsCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>

                    <td>&nbsp;
                    </td>

                    <td>Select Subcategory</td>
                    <td>
                        <asp:DropDownList ID="ddl_newsSubCategory" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>News Title
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>News Date
                    </td>
                    <td>
                        <%-- <asp:TextBox ID="txtNewsDate" runat="server"></asp:TextBox>--%>

                        <asp:TextBox ID="txtNewsDate" ReadOnly="false" Visible="true"
                            placeholder="Select Date"
                            autocomplete="off" CssClass="reservation_txt_width" runat="server"></asp:TextBox>

                        <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage="Required"
                    ControlToValidate="txtNewsDate"></asp:RequiredFieldValidator>--%>

                        <ajaxToolkit:CalendarExtender ID="FromCalendar" runat="server" TargetControlID="txtNewsDate" PopupPosition="BottomRight" Format="MM/dd/yyyy">
                        </ajaxToolkit:CalendarExtender>

                        <ajaxToolkit:FilteredTextBoxExtender ID="FromCalendarFilter" runat="server" TargetControlID="txtNewsDate"
                            FilterType="Numbers, Custom" ValidChars="/" />
                    </td>
                </tr>

                <tr>
                    <td>News Tags
                    </td>
                    <td>
                        <asp:TextBox ID="txtTags" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>News Author
                    </td>
                    <td>
                        <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="5">News Content
                    <br />
                        <asp:TextBox ID="txtContent" Text=" " runat="server" Height="400px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        <ajaxToolkit:HtmlEditorExtender DisplaySourceTab="true" ID="HtmlEditorExtenderContent"
                            OnImageUploadComplete="HtmlEditorExtenderContent_ImageUploadComplete"
                            EnableSanitization="false" TargetControlID="txtContent" runat="server">
                            <Toolbar>
                                <ajaxToolkit:Undo />
                                <ajaxToolkit:Redo />
                                <ajaxToolkit:Bold />
                                <ajaxToolkit:Italic />
                                <ajaxToolkit:Underline />
                                <ajaxToolkit:StrikeThrough />
                                <ajaxToolkit:Subscript />
                                <ajaxToolkit:Superscript />
                                <ajaxToolkit:JustifyLeft />
                                <ajaxToolkit:JustifyCenter />
                                <ajaxToolkit:JustifyRight />
                                <ajaxToolkit:JustifyFull />
                                <ajaxToolkit:InsertOrderedList />
                                <ajaxToolkit:InsertUnorderedList />
                                <ajaxToolkit:CreateLink />
                                <ajaxToolkit:UnLink />
                                <ajaxToolkit:RemoveFormat />
                                <ajaxToolkit:SelectAll />
                                <ajaxToolkit:UnSelect />
                                <ajaxToolkit:Delete />
                                <ajaxToolkit:Cut />
                                <ajaxToolkit:Copy />
                                <ajaxToolkit:Paste />
                                <ajaxToolkit:BackgroundColorSelector />
                                <ajaxToolkit:ForeColorSelector />
                                <ajaxToolkit:FontNameSelector />
                                <ajaxToolkit:FontSizeSelector />
                                <ajaxToolkit:Indent />
                                <ajaxToolkit:Outdent />
                                <ajaxToolkit:InsertHorizontalRule />
                                <ajaxToolkit:HorizontalSeparator />
                                <ajaxToolkit:InsertImage />
                            </Toolbar>
                        </ajaxToolkit:HtmlEditorExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Button ID="litMsg" runat="server" EnableViewState="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="save" />
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
