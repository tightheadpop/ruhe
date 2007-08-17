<%@ Page language="c#" Codebehind="InputDropDownRequired.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.Tests.Web.UI.Controls.InputDropDownRequired" %>
<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<form id="InputDropDownListTests" method="post" runat="server">
	<asp:validationsummary id="summary" runat="Server"/>
	<ruhe:inputdropdownlist id="DropDownTest" runat="server" Required="True"/>
	<asp:button id="submitButton" runat="Server"/>
</form>
