<%@ Page Language="C#" MasterPageFile="~/Ajax.Master" AutoEventWireup="true" CodeBehind="MessageFlash.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.MessageFlash" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:Message id="flash" FlashHost="true" runat="server" />
    <asp:Button OnClick="submit_Click" ID="submit" runat="server" />
</asp:Content>
