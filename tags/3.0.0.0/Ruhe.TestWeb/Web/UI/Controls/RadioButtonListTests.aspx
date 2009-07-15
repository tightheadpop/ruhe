<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioButtonListTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.RadioButtonListTests" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <ruhe:RadioButtonList ID="postBackList" runat="server" AutoPostBack="true">
        <asp:ListItem Text="a"/>
        <asp:ListItem Text="b" Selected="True"/>
        <asp:ListItem Text="c"/>
    </ruhe:RadioButtonList>
    
    <ruhe:RadioButtonList ID="nonPostBackList" runat="server" AutoPostBack="false">
        <asp:ListItem Selected="True" Text="a"/>
        <asp:ListItem Text="b"/>
        <asp:ListItem Text="c"/>
    </ruhe:RadioButtonList>
    
</asp:Content>