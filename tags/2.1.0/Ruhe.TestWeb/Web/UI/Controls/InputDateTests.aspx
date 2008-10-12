<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputDateTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputDateTests" MasterPageFile="~/Ajax.Master" %>
<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:inputdate id="date" runat="server" Format="M/d/yyyy" />
    <ruhe:InputDate ID="readOnly" ReadOnly="true" runat="server" />
</asp:Content>