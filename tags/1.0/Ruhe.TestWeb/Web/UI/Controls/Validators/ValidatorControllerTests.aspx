<%@ Page language="c#" Codebehind="ValidatorControllerTests.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.TestWeb.Web.UI.Controls.Validators.ValidatorControllerTests" %>
<%@ Register TagPrefix="Ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<form id="Form1" method="post" runat="server">
	<asp:ValidationSummary id="summary" runat="server"/>
	<ruhe:InputTextBox id="ruheTextBox" Required="True" runat="server" LabelText="Ruhe"/>
	<asp:Button id="submit" runat="server"/>
</form>
