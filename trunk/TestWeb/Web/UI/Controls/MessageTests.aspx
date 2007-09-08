<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageTests.aspx.cs" Inherits="Web_UI_Controls_MessageTests" %>

<%@ Register Assembly="Ruhe.Web" Namespace="Ruhe.Web.UI.Controls" TagPrefix="ruhe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<ruhe:Message ID="message1" runat="Server" HeaderText="This is header text" Type="Confirmation">
				<a id="dummyLink" href="#" runat="server">Stuff here</a>
			</ruhe:Message>
			<ruhe:Message ID="message2" runat="Server" HeaderText="Just a header" />
			<ruhe:Message ID="message3" runat="Server">
				just body content
			</ruhe:Message>
			<ruhe:Message ID="message4" runat="Server" />
			<ruhe:Message ID="message5" runat="server" HeaderText="header text">
				<asp:Label ID="bogus" runat="server" Text="bogus" />
			</ruhe:Message>
			<asp:Button ID="addControl" runat="server" Text="add control to message" OnClick="addControl_Click" />
		</div>
	</form>
</body>
</html>
