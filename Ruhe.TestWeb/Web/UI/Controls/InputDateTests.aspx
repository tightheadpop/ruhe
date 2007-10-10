<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputDateTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputDateTests" MasterPageFile="~/Ajax.Master" %>
<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:InputDate ID="date" runat="server" />
    <ruhe:InputDate ID="readonly" ReadOnly="true" runat="server" />
</asp:Content>