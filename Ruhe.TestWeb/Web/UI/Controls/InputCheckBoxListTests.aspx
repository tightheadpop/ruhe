<%@ Page MasterPageFile="~/Ajax.Master" Language="C#" AutoEventWireup="true" CodeBehind="InputCheckBoxListTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputCheckBoxListTests" %>
<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:InputCheckBoxList runat="server" id ="checkboxlist" DataValueField="Value" DataTextField="Text" />
</asp:Content>