<%@ Page AutoEventWireup="true" Codebehind="InputTextBoxReadOnly.aspx.cs" Inherits="Web_UI_Controls_InputTextBoxReadOnly" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:ValidationSummary ID="summary" runat="server" />
	<ruhe:InputTextBox ID="testBox1" ReadOnly="True" Required="True" runat="server" />
	<ruhe:InputTextBox ID="testBox2" runat="server" />
	<asp:Button ID="submitButton" Text="Submit" runat="server" />
	<asp:Label ID="result" runat="server" EnableViewState="false" />
</asp:Content>
