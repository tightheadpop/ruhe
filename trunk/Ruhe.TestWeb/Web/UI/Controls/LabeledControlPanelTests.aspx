<%@ Page AutoEventWireup="true" Codebehind="LabeledControlPanelTests.aspx.cs" Inherits="Web_UI_Controls_LabeledControlPanelTests" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<ruhe:LabeledControlPanel ID="panel" runat="Server" LabelPosition="Left">
		<ruhe:InputTextBox ID="textbox" runat="server" FormatText="(&amp;times;10&lt;sup&gt;6&lt;/sup&gt;)" LabelText="label" />
	</ruhe:LabeledControlPanel>
</asp:Content>
