<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sample" Codebehind="Sample.aspx.cs" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:Message ID="confirmationMessage" Visible="false" Type="Confirmation" runat="server" HeaderText="Confirmation" EnableViewState="false">
        Thank you for submitting.
    </ruhe:Message>
	<ruhe:LabeledControlPanel runat="server" GroupingText="Sample Form">
		<ruhe:InputTextBox LabelText="Name" ID="name" runat="server" Required="true" />
		<ruhe:InputEmailAddress ID="email" runat="server" Required="true" />
		<ruhe:InputNumber LabelText="Your Age" NumericFormat="Integer" ID="age" runat="server" />
		<ruhe:ControlGroup runat="server">
			<ruhe:SaveButton ID="saveButton" runat="server" OnClick="saveButton_Click"/>
			<ruhe:ResetButton runat="server" />
		</ruhe:ControlGroup>
	</ruhe:LabeledControlPanel>
</asp:Content>
