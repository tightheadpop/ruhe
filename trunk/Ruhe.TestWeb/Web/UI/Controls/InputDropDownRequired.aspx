<%@ Page AutoEventWireup="true" Codebehind="InputDropDownRequired.aspx.cs" Inherits="Web_UI_Controls_InputDropDownRequired" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:ValidationSummary ID="summary" runat="Server" />
	<ruhe:InputDropDownList ID="DropDownTest" runat="server" Required="True" />
	<asp:Button ID="submitButton" runat="Server" />
</asp:Content>
