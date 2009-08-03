<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputDerivedTypeDropDownListTests.aspx.cs" Inherits="Ruhe.TestWeb.Web.UI.Controls.InputDerivedTypeDropDownListTests" MasterPageFile="~/Ajax.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<test:SampleDerivedTypeList runat="server" ID="list" AutoPostBack="true" OnSelectedIndexChanged="Change" />
	<asp:Label runat="server" id="label" />

	<test:SampleDerivedTypeList runat="server" ID="otherList" AutoPostBack="true" OnSelectedIndexChanged="Change" />
	<asp:Label runat="server" id="otherLabel" />
</asp:Content>
