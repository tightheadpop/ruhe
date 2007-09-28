<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web_UI_Controls_InputTextBoxReadOnly" Codebehind="InputTextBoxReadOnly.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
	    <asp:ValidationSummary id="summary" runat="server"/>
        <ruhe:InputTextBox id="testBox1" ReadOnly="True" Required="True" runat="server"/>
        <ruhe:InputTextBox id="testBox2" runat="server"/>
	    <asp:Button id="submitButton" Text="Submit" runat="server"/>
	    <asp:Label id="result" runat="server" enableviewstate="false"/>
    </div>
    </form>
</body>
</html>
