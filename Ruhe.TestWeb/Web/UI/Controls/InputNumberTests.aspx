<%@ Register TagPrefix="ruhe" Namespace="Ruhe.Web.UI.Controls" Assembly="Ruhe.Web" %>
<%@ Page language="c#" Codebehind="InputNumberTests.aspx.cs" AutoEventWireup="false" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputNumberTestsPage" %>


    <form id="Form1" method="post" runat="server">
			<asp:ValidationSummary ID="summary" Runat="server" />
			<ruhe:InputNumber runat="server" id="inputNumber" enableclientscript="false" />
			<asp:Button ID="submitButton" Runat="server" />
			
     </form>
