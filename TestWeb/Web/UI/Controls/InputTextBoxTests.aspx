<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputTextBoxTests.aspx.cs"
    Inherits="Web_UI_Controls_InputTextBoxTests" %>

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
            <ruhe:InputTextBox Width="20" LabelText="testBox" ID="testBox" runat="server" CssClass="test" />
            <ruhe:InputTextBox Visible="false" ID="aspxRequired" Required="true" runat="server" />
            <asp:Button ID="submitButton" Text="Submit" runat="server" />
            <asp:Label ID="result" runat="server" EnableViewState="false" />
        </div>
    </form>
</body>
</html>
