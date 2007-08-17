<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<%@ Page language="c#" Codebehind="InputDropDownReadOnly.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.Tests.Web.UI.Controls.InputDropDownReadOnly" %>
<form id="InputDropDownReadOnly" method="post" runat="server">
	<ruhe:InputDropDownList id="readOnlyList" runat="server" ReadOnly="True" />
	<ruhe:InputDropDownList id="readOnlyTrueListMultiItem" runat="server" ReadOnly="True" />
	<ruhe:InputDropDownList id="readOnlyFalseListMultiItem" runat="server" ReadOnly="False" AutoPostBack="True" />
	<asp:ValidationSummary id="summary" runat="Server" />
	<asp:button id="submitButton" runat="Server" />
</form>
