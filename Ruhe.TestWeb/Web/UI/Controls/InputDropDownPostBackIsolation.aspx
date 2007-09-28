<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="Web_UI_Controls_InputDropDownPostBackIsolation" Codebehind="InputDropDownPostBackIsolation.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ruhe:inputdropdownlist OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" id="DropDownList1" runat="server" autopostback="True" />
            <ruhe:inputdropdownlist OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" id="DropDownList2" runat="server" autopostback="True" />
            <asp:TextBox ID="ByProduct1" runat="server">did not fire</asp:TextBox>
            <asp:TextBox ID="ByProduct2" runat="server">did not fire</asp:TextBox>
        </div>
    </form>
</body>
</html>
