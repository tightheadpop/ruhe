<%@ Page AutoEventWireup="true" Codebehind="InputDropDownAutoPostBackDisplay.aspx.cs" Inherits="Web_UI_Controls_InputDropDownAutoPostBackDisplay" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<div>
		<ruhe:InputDropDownList OnSelectedIndexChanged="firstDropDownList_SelectedIndexChanged" ID="firstDropDownList" runat="server" AutoPostBack="True" />
		<ruhe:InputDropDownList ID="secondDropDownList" runat="server" /></div>
	<div>
		<ruhe:InputDropDownList OnSelectedIndexChanged="thirdDropDownList_SelectedIndexChanged" ID="thirdDropDownList" runat="server" AutoPostBack="True" />
		<ruhe:InputDropDownList ID="fourthDropDownList" runat="server" /></div>
</asp:Content>
