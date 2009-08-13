<%@ Page Language="C#" MasterPageFile="~/Ajax.Master" AutoEventWireup="true" CodeBehind="InputTextBoxMultiLineMaxLength.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputTextBoxMultiLineMaxLength" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:InputTextBox ID="limitedInput" TextMode="MultiLine" runat="server" MaxLength="10" />
</asp:Content>