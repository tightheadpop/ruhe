<%@ Page AutoEventWireup="true" Codebehind="InputDropDownListTesterTests.aspx.cs" Inherits="Ruhe.TestWeb.InputDropDownListTesterTests" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:DropDownList ID="dropDownList" runat="server" AutoPostBack="True">
		<asp:ListItem Value="zero" Selected="True">Zero</asp:ListItem>
		<asp:ListItem Value="one">One</asp:ListItem>
		<asp:ListItem Value="two">Two</asp:ListItem>
		<asp:ListItem Value="three">Three</asp:ListItem>
		<asp:ListItem Value="four">Four</asp:ListItem>
	</asp:DropDownList>
</asp:Content>
