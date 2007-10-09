<%@ Page AutoEventWireup="true" Codebehind="MessageTests.aspx.cs" Inherits="Web_UI_Controls_MessageTests" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
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
</asp:Content>
