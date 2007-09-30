<%@ Page AutoEventWireup="true" Codebehind="InputDropDownReadOnly.aspx.cs" Inherits="Web_UI_Controls_InputDropDownReadOnly" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<ruhe:InputDropDownList ID="readOnlyList" runat="server" ReadOnly="True" />
	<ruhe:InputDropDownList ID="readOnlyTrueListMultiItem" runat="server" ReadOnly="True" />
	<ruhe:InputDropDownList ID="readOnlyFalseListMultiItem" runat="server" ReadOnly="False" AutoPostBack="True" />
	<asp:ValidationSummary ID="summary" runat="Server" />
	<asp:Button ID="submitButton" runat="Server" />
</asp:Content>
