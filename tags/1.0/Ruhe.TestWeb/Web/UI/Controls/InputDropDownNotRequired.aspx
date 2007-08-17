<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<%@ Page language="c#" Codebehind="InputDropDownNotRequired.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.Tests.Web.UI.Controls.InputDropDownNotRequired" %>
<form id="InputDropDownListTests" method="post" runat="server">
	<asp:ValidationSummary id="summary" runat="Server"/>
	<ruhe:inputdropdownlist id="DropDownTest" runat="server" />
	<asp:button id="submitButton" runat="Server"/>
</form>
