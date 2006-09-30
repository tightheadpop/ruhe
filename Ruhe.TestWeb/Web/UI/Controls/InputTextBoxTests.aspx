<%@ Page language="c#" Codebehind="InputTextBoxTests.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.Tests.Web.UI.Controls.InputTextBoxTestsPage" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<form runat="server" ID="Form1">
	<asp:ValidationSummary id="summary" runat="server"/>
	<ruhe:InputTextBox width="20" labeltext="testBox" id="testBox" runat="server" CssClass="test"/>
	<ruhe:InputTextBox visible="false" id="aspxRequired" required="true" runat="server" />
	<asp:Button id="submitButton" Text="Submit" runat="server"/>
	<Asp:Label id="result" runat="server" enableviewstate="false"/>
</form>
