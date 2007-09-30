<%@ Page AutoEventWireup="true" Codebehind="ButtonTests.aspx.cs" Inherits="Web_UI_Controls_ButtonTests" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:Label ID="result" runat="server" />
	<ruhe:InputTextBox ID="doesNotMatter" runat="server" Required="true" ValidationGroup="Stooge" />
	<ruhe:Button ID="button1" runat="server" ImageUrl="~/images/foo.gif" Text="&Submit" ValidationGroup="Stooge" CausesValidation="true" OnClick="button1_Click" />
	<ruhe:Button ID="button2" runat="server" Text="Click Here" CausesValidation="false" OnClick="button2_Click" />
</asp:Content>
