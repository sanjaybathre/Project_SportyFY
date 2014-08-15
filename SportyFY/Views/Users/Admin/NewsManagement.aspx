<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="NewsManagement.aspx.cs" Inherits="SportyFY.Views.Users.Admin.NewsManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <table>
            <tr>
                <td>Select Category</td>
                <td>
                    <asp:DropDownList ID="ddl_newsCategory" runat="server"></asp:DropDownList>
                </td>
                
                <td>
                    &nbsp;
                </td>

                <td>Select Subcategory</td>
                <td>
                    <asp:DropDownList ID="ddl_newsSubCategory" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    News Title
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    News Date
                </td>
                <td>
                    <asp:TextBox ID="txtNewsDate" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    News Tags
                </td>
                <td>
                    <asp:TextBox ID="txtTags" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    News Author
                </td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="5">
                    News Content
                    <br /><br />
                    <%--<ajaxToolkit:Editor ID="ccEditContent" runat="server" ></ajaxToolkit:Editor>--%>
                    <cc1:Editor ID="Editor1" runat="server" />

                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnSave" runat="server" Text="save"/>
                </td>
            </tr>
        </table>
</asp:Content>
