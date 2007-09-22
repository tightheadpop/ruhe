<%@ Page AutoEventWireup="true" CodeFile="ButtonTests.aspx.cs" Inherits="Web_UI_Controls_ButtonTests" Language="C#" %>
<%@ Register Assembly="Ruhe.Web" Namespace="Ruhe.Web.UI.Controls" TagPrefix="ruhe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Label ID="result" runat="server" />
		<ruhe:InputTextBox ID="doesNotMatter" runat="server" Required="true" />
		<ruhe:Button ID="button1" runat="server" ImageUrl="~/images/foo.gif" Text="&Submit" CausesValidation="true" OnClick="button1_Click" />
		<ruhe:Button ID="button2" runat="server" Text="Click Here" CausesValidation="false" OnClick="button2_Click"/>
    </div>
    </form>
</body>
</html>
