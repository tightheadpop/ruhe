<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputIntegerTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputIntegerTests" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <asp:ValidationSummary ID="summary" runat="server" />
    <ruhe:InputInteger ID="inputPositiveInteger" runat="server" EnableClientScript="false" MaximumValue="24" MinimumValue="0"/>
    <ruhe:InputInteger ID="inputInteger" runat="server" EnableClientScript="false" MaximumValue="24" MinimumValue="-24"/>
    <asp:Button ID="submitButton" runat="server" />
</asp:Content>