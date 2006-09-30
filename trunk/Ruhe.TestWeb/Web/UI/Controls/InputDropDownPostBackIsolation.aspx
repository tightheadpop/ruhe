<%@ Page language="c#" Codebehind="InputDropDownPostBackIsolation.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.Tests.Web.UI.Controls.InputDropDownPostBackIsolation" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<form id="InputDropDownPostBackIsolation" method="post" runat="server" action="InputDropDownPostBackIsolation.aspx">
	<ruhe:InputDropDownList id="DropDownList1" runat="server" AutoPostBack="True" />
	<ruhe:InputDropDownList id="DropDownList2" runat="server" AutoPostBack="True" />
	<asp:TextBox id="ByProduct1" runat="server">did not fire</asp:TextBox>
	<asp:TextBox id="ByProduct2" runat="server">did not fire</asp:TextBox>
</form>
