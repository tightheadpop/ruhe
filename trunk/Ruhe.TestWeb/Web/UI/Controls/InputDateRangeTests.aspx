<%@ Page MasterPageFile="~/Ajax.Master" Language="C#" AutoEventWireup="true" CodeBehind="InputDateRangeTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputDateRangeTests" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:InputDateRange id="input" Required="true" runat="server" />
    <ruhe:InputDateRange id="readOnlyInput" ReadOnly="true" runat="server" />
</asp:Content>