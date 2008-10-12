<%@ Page AutoEventWireup="true" Codebehind="InputDropDownPostBackIsolation.aspx.cs" Inherits="Web_UI_Controls_InputDropDownPostBackIsolation" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<ruhe:InputDropDownList OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ID="DropDownList1" runat="server" AutoPostBack="True" />
	<ruhe:InputDropDownList OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ID="DropDownList2" runat="server" AutoPostBack="True" />
	<asp:TextBox ID="ByProduct1" runat="server">did not fire</asp:TextBox>
	<asp:TextBox ID="ByProduct2" runat="server">did not fire</asp:TextBox>
</asp:Content>
