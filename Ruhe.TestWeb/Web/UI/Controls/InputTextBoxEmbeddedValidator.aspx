<%@ Page Language="C#" MasterPageFile="~/Ajax.Master" AutoEventWireup="true" CodeBehind="InputTextBoxEmbeddedValidator.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputTextBoxEmbeddedValidator" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:ValidationSummary ID="summary" runat="server" />
	<ruhe:InputTextBox Width="20" LabelText="testBox" Text="non-blank" ID="testBox" runat="server" CssClass="test" ErrorMessage="you're wrong.">
	    <asp:CustomValidator ID="customValidator" ControlToValidate="testBox" runat="server" OnServerValidate="AlwaysFail" />
	</ruhe:InputTextBox>
	<asp:Button ID="submitButton" Text="Submit" runat="server" />
</asp:Content>
