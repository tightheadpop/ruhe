<%@ Page language="c#" Codebehind="LinkButtonTests.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.TestWeb.Web.UI.Controls.LinkButtonTests" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<form id="Form1" method="post" runat="server">
	<asp:Label id="target" runat="server"/>
	<ruhe:LinkButton id="linkButton" Text="Click Me" runat="Server"/>
</form>
