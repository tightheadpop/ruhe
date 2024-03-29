<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sample" Codebehind="Sample.aspx.cs" MasterPageFile="~/Ajax.Master" %>
<%@ Register Src="~/AnotherLayoutContainer.ascx" TagName="AnotherLayoutContainer" TagPrefix="test" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:Message ID="confirmationMessage" FlashHost="true" runat="server" />
	<ruhe:LabeledControlPanel runat="server" GroupingText="Sample Form">
		<ruhe:InputTextBox LabelText="Name" ID="name" runat="server" Required="true" />
		<ruhe:InputEmailAddress ID="email" runat="server" Required="true" />
		<ruhe:InputDate ID="date" LabelText="Date" Required="true" runat="server" DefaultToToday="true" />
		<ruhe:InputInteger LabelText="Your Age" ID="age" runat="server" />
		<ruhe:InputNumber id="height" LabelText="Height (m)" runat="server" />
		<ruhe:InputDateRange id="range" LabelText="Date Range" Required="true" runat="server" />
		<ruhe:InputTextBox ID="comments" LabelText="Comments" runat="server" MaxLength="30" TextMode="MultiLine" />
        <test:AnotherLayoutContainer ID="AnotherLayoutContainer1" runat="server" />
		<ruhe:ControlGroup runat="server">
			<ruhe:SaveButton ID="saveButton" runat="server" OnClick="Save"/>
			<ruhe:CancelButton runat="server" OnClick="Cancel" />
		</ruhe:ControlGroup>
	</ruhe:LabeledControlPanel>
	<ruhe:Legend runat="server" GroupingText="Legend" />
</asp:Content>
