<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<%@ Page language="c#" Codebehind="LabeledControlPanelTests.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.TestWeb.Web.UI.Controls.LabeledControlPanelTests" %>
<form id="labeledControlPanel" method="post" runat="server">
	<ruhe:LabeledControlPanel id="panel" runat="Server" labelposition="Left">
		<ruhe:InputTextBox id="textbox" runat="server" LabelText="label" FormatText="(format)"/>
	</ruhe:LabeledControlPanel>
</form>
