<%@ Page AutoEventWireup="true" Codebehind="InputNumberTests.aspx.cs" Inherits="Web_UI_Controls_InputNumberTests" Language="C#" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<asp:ValidationSummary ID="summary" runat="server" />
	<ruhe:InputNumber runat="server" ID="inputNumber" MaximumValue="24" MinimumValue="0" EnableClientScript="false" />
	<asp:Button ID="submitButton" runat="server" />
</asp:Content>
