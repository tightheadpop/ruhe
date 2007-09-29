<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateLabelTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.UpdateLabelTests" MasterPageFile="~/Ajax.Master" %>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<ruhe:UpdateLabel id="updateLabel" runat="server">
		<ContentTemplate>
			<asp:Label ID="proof" runat="server" />
			<ruhe:SaveButton ID="saveButton" runat="server" OnClick="saveButton_Click" />
		</ContentTemplate>
	</ruhe:UpdateLabel>
</asp:Content>
