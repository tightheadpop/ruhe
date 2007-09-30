<%@ Page AutoEventWireup="true" Codebehind="LinkButtonTests.aspx.cs" Inherits="Web_UI_Controls_LinkButtonTests" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:Label ID="target" runat="server"></asp:Label>
	<ruhe:LinkButton ID="linkButton" runat="Server" Text="Click Me" OnClick="linkButton_Click" />
</asp:Content>
