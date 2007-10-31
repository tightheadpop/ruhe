<%@ Page AutoEventWireup="true" Codebehind="LabeledControlPanelTests.aspx.cs" Inherits="Web_UI_Controls_LabeledControlPanelTests" Language="C#" MasterPageFile="~/Ajax.Master" %>
<%@ Register Src="~/AnotherLayoutContainer.ascx" TagName="AnotherLayoutContainer" TagPrefix="test" %>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<ruhe:LabeledControlPanel ID="panel" runat="Server" LabelPosition="Left">
		<ruhe:InputTextBox ID="textbox" runat="server" FormatText="(&amp;times;10&lt;sup&gt;6&lt;/sup&gt;)" LabelText="label" />
        <test:AnotherLayoutContainer ID="userControl" runat="server"/>
    </ruhe:LabeledControlPanel>
</asp:Content>
