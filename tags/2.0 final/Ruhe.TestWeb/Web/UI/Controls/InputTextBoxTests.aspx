<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Ajax.master" Inherits="Web_UI_Controls_InputTextBoxTests" Codebehind="InputTextBoxTests.aspx.cs" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:ValidationSummary ID="summary" runat="server" />
	<ruhe:InputTextBox Width="20" LabelText="testBox" ID="testBox" runat="server" CssClass="test" ErrorMessage="you're wrong" />
	<ruhe:InputTextBox Visible="false" ID="aspxRequired" Required="true" runat="server" />
	<asp:Button ID="submitButton" Text="Submit" runat="server" />
	<asp:Label ID="result" runat="server" EnableViewState="false" />
</asp:Content>
