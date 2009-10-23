<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HyperLinkFieldTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.HyperLinkFieldTests" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <ruhe:HyperLinkField HeaderText="ID" DataNavigateUrlFormatString="~/HyperLinkField.aspx?Id={0}" DataNavigateUrlFields="Bar.Id" DataTextField="Bar.Id" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
