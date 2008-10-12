<%@ Page AutoEventWireup="true" Codebehind="InputDropDownNotRequired.aspx.cs" Inherits="Web_UI_Controls_InputDropDownNotRequired" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:ValidationSummary ID="summary" runat="Server" />
	<ruhe:InputDropDownList ID="DropDownTest" runat="server" />
	<asp:Button ID="submitButton" runat="Server" />
</asp:Content>
