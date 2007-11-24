<%@ Page AutoEventWireup="true" Codebehind="InputEnumTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputEnumTests" Language="C#" MasterPageFile="~/Ajax.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="content">
    <ruhe:InputEnum id="noInitialBlank" EnumType="Ruhe.Common.Month, Ruhe.Common" runat="server" />
    <ruhe:InputEnum id="initialBlank" runat="server" EnumType="Ruhe.Common.Month, Ruhe.Common" InitialBlank="true"/>
</asp:Content>
