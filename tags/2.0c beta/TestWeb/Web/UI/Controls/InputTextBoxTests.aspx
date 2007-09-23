<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputTextBoxTests.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Web_UI_Controls_InputTextBoxTests" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<asp:Content ContentPlaceHolderID="body" runat="server">
	<asp:ValidationSummary ID="summary" runat="server" />
	<ruhe:InputTextBox Width="20" LabelText="testBox" ID="testBox" runat="server" CssClass="test" ErrorMessage="you're wrong" />
	<ruhe:InputTextBox Visible="false" ID="aspxRequired" Required="true" runat="server" />
	<asp:Button ID="submitButton" Text="Submit" runat="server" />
	<asp:Label ID="result" runat="server" EnableViewState="false" />
</asp:Content>
