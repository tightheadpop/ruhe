<%@ Page language="c#" Codebehind="MessageTests.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.TestWeb.Web.UI.Controls.MessageTestsPage" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<form id="Form1" method="post" runat="server">

	<ruhe:Message id="message1" Type="Confirmation" runat="Server" HeaderText="This is header text">
		<a id="dummyLink" href="#" runat="server">Stuff here</a>
	</ruhe:Message>
	
	<ruhe:Message id="message2" runat="Server" headertext="Just a header"/>
	<ruhe:Message id="message3" runat="Server">just body content</ruhe:Message>
	<ruhe:Message id="message4" runat="Server"/>
	<ruhe:Message id="message5" runat="server" HeaderText="header text">
		<asp:Label id="bogus" runat="server" Text="bogus"/>
	</ruhe:Message>
	
	<Asp:button id="addControl" Text="add control to message" runat="server"/>

</form>
