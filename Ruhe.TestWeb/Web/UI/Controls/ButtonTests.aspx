<%@ Page AutoEventWireup="true" Inherits="Web_UI_Controls_ButtonTests" Language="C#" Codebehind="ButtonTests.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Label ID="result" runat="server" />
		<ruhe:InputTextBox ID="doesNotMatter" runat="server" Required="true" ValidationGroup="Stooge" />
		<ruhe:Button ID="button1" runat="server" ImageUrl="~/images/foo.gif" Text="&Submit" ValidationGroup="Stooge" CausesValidation="true" OnClick="button1_Click" />
		<ruhe:Button ID="button2" runat="server" Text="Click Here" CausesValidation="false" OnClick="button2_Click"/>
    </div>
    </form>
</body>
</html>
