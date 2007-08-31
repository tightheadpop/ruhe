<%@ Page language="c#" Codebehind="InputTextBoxReadOnly.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputTextBoxReadOnly" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<form runat="server" ID="Form1">
	<asp:ValidationSummary id="summary" runat="server"/>
<ruhe:InputTextBox id="testBox1" ReadOnly="True" Required="True" runat="server"/>
<ruhe:InputTextBox id="testBox2" runat="server"/>
	<asp:Button id="submitButton" Text="Submit" runat="server"/>
	<asp:Label id="result" runat="server" enableviewstate="false"/>
</form>
