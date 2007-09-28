<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web_UI_Controls_LinkButtonTests" Codebehind="LinkButtonTests.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Label ID="target" runat="server"></asp:Label>
		<ruhe:linkbutton id="linkButton" runat="Server" text="Click Me" OnClick="linkButton_Click"/>
	</div>
    </form>
</body>
</html>
