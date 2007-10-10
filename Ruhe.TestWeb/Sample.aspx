<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sample" Codebehind="Sample.aspx.cs" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:Message ID="confirmationMessage" Visible="false" Type="Confirmation" runat="server" HeaderText="Confirmation" EnableViewState="false">
        Thank you for submitting.
    </ruhe:Message>
	<ruhe:LabeledControlPanel runat="server" GroupingText="Sample Form">
		<ruhe:InputTextBox LabelText="Name" ID="name" runat="server" Required="true" />
		<ruhe:InputEmailAddress ID="email" runat="server" Required="true" />
		<ruhe:InputDate ID="date" LabelText="Date" Required="true" runat="server" DefaultToToday="true" />
		<ruhe:InputInteger LabelText="Your Age" ID="age" runat="server" />
		<ruhe:InputNumber id="height" LabelText="Height (m)" runat="server" />
		<ruhe:ControlGroup runat="server">
			<ruhe:SaveButton ID="saveButton" runat="server" OnClick="Save"/>
			<ruhe:CancelButton runat="server" OnClick="Cancel" />
		</ruhe:ControlGroup>
	</ruhe:LabeledControlPanel>
</asp:Content>
