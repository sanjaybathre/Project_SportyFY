<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SportyFY.Views.Authentication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="LoginSporty" OnLoggedIn="LoginSporty_LoggedIn" OnLoginError="LoginSporty_LoginError" runat="server">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <td>Email</td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Password</td>
                            <td>
                                <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="LoginButton" CommandName="Login" Text="Login" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me" />
                            </td>
                            <td>
                                <span><a href="#">Forgot Password?</a></span>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </form>
</body>
</html>
