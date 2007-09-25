<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputDropDownReadOnly.aspx.cs"
    Inherits="Web_UI_Controls_InputDropDownReadOnly" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ruhe:inputdropdownlist id="readOnlyList" runat="server" readonly="True" />
            <ruhe:inputdropdownlist id="readOnlyTrueListMultiItem" runat="server" readonly="True" />
            <ruhe:inputdropdownlist id="readOnlyFalseListMultiItem" runat="server" readonly="False"
                autopostback="True" />
            <asp:ValidationSummary ID="summary" runat="Server" />
            <asp:Button ID="submitButton" runat="Server" />
        </div>
    </form>
</body>
</html>
