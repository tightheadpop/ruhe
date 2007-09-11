<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputNumberTests.aspx.cs"
    Inherits="Web_UI_Controls_InputNumberTests" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="summary" runat="server" />
            <ruhe:inputnumber runat="server" id="inputNumber" enableclientscript="false" />
            <asp:Button ID="submitButton" runat="server" />
        </div>
    </form>
</body>
</html>
