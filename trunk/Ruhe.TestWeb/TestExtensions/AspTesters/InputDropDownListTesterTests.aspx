<%@ Page Language="C#" AutoEventWireup="true" Inherits="Ruhe.TestWeb.InputDropDownListTesterTests" Codebehind="InputDropDownListTesterTests.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="dropDownList" Runat="server" AutoPostBack="True">
	        <asp:ListItem Value="zero" Selected="True">Zero</asp:ListItem>
	        <asp:ListItem Value="one">One</asp:ListItem>
	        <asp:ListItem Value="two">Two</asp:ListItem>
	        <asp:ListItem Value="three">Three</asp:ListItem>
	        <asp:ListItem Value="four">Four</asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
